//------------------------------------------------------------------------------ 
// <copyright file="ActiveDirectoryWrapper.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A Wrapper class to encapsulate Active Directory communication interface.
    ///     This class provides service to connect with active diretory and 
    ///     to create active diretory users and assigns groups. 
    ///     
    ///     Created By : Majid Akhter       Created Date : 08/02/2019	
    ///     Modified By : Name            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public class ActiveDirectoryWrapper : IDisposable
    {
        #region Private member Variables

        /// <summary>
        ///     active directory connection string
        /// </summary>
        private string activeDirectoryConnectionString;

        /// <summary>
        ///     active directory domain user 
        /// </summary>
        private string activeDirectoryUserName;

        /// <summary>
        ///     active directory domain user passsword 
        /// </summary>
        private string activeDirectoryPassword;

        /// <summary>
        ///     active directory domain
        /// </summary>
        private PrincipalContext activeDirectoryDomain;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initalize and connect with active directory.
        /// </summary>
        public ActiveDirectoryWrapper(string adsPath, string adsUser, string adsPassword)
        {
            this.activeDirectoryConnectionString = adsPath;
            this.activeDirectoryUserName = adsUser;
            this.activeDirectoryPassword = adsPassword;
            try
            {
                this.activeDirectoryDomain = new PrincipalContext(ContextType.Domain
                       , this.activeDirectoryConnectionString
                       , this.activeDirectoryUserName
                       , this.activeDirectoryPassword);
            }
            catch (PrincipalServerDownException npx)
            {
                throw new ApplicationException("Unable to access domain.", npx);
            }
            catch (Exception ex)
            {
                //throw new ApplicationException("User account does not exists.");
                throw ex;
            }
        }
        #endregion

        #region Public Accessor
        /// <summary>
        ///     Get current active directory domain
        /// </summary>
        public PrincipalContext ActiverDirectoryDomain
        {
            get { return this.activeDirectoryDomain; }
        }
        #endregion 

        #region Public Methods
        /// <summary>
        ///     Creates a user account in activer directory domain.
        /// </summary>
        /// <param name="firstName">first name for user</param>
        /// <param name="middleName">middle name for user</param>
        /// <param name="lastName">last name for user</param>
        /// <param name="loginName">user account login name</param>
        /// <param name="password">user account password</param>
        /// <param name="email">user emailid</param>
        /// <param name="userCompanyName">user company name</param>
        public void CreateUserAccount(string firstName, string middleName, string lastName
            , string loginName, string email, string userCompanyName)
        {
            try
            {
                UserPrincipal userEntry = new UserPrincipal(activeDirectoryDomain);

                userEntry.GivenName = firstName;
                userEntry.MiddleName = middleName;
                userEntry.Surname = lastName;
                userEntry.Name = string.Format("{0} {1} {2}", firstName, middleName, lastName);
                userEntry.DisplayName = string.Format("{0} {1} {2}", firstName, middleName, lastName);
                userEntry.SamAccountName = loginName;
                userEntry.UserPrincipalName = loginName;
                userEntry.PasswordNeverExpires = true;
                userEntry.EmailAddress = email;
                userEntry.Description = string.Format("Employee of company {0}", userCompanyName);
                userEntry.Enabled = true;
                userEntry.Save();
                userEntry.Dispose();
            }
            catch (PrincipalExistsException px)
            {
                throw new TerminalServerLoginIdExistsException("User login name already exists.", px);
            }
            catch (Exception ex)
            {
                //throw new ApplicationException("User account does not exists.");
                throw ex;
            }
        }

        /// <summary>
        /// Set the password for user in domain
        /// </summary>
        /// <param name="loginName">domain user name</param>
        /// <param name="oldPassword">old password</param>
        /// <param name="password">new password</param>
        public void SetPassword(string loginName, string oldPassword, string password)
        {
            try
            {
                // Find user entry by login name
                UserPrincipal userEntry = UserPrincipal.FindByIdentity(activeDirectoryDomain,
                    IdentityType.SamAccountName,
                    loginName);
                userEntry.ChangePassword(oldPassword, password);
                userEntry.Dispose();
            }
            catch (PasswordException px)
            {
                throw new InvalidPasswordException("Invalid Password", px);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Makes user with given login name member of group with given name if exists.
        /// </summary>
        /// <param name="groupName">group name</param>
        public void AssignUserGroup(string loginName, string groupName)
        {
            // Find user entry by login name
            UserPrincipal userEntry = UserPrincipal.FindByIdentity(activeDirectoryDomain,
                IdentityType.SamAccountName,
                loginName);

            // Search for group with matching name
            PrincipalSearchResult<Principal> activeDirectoryGroups = this.ListGroupsByName(
                this.activeDirectoryDomain, groupName);
            if (activeDirectoryGroups.Count<Principal>() != 0)
            {
                GroupPrincipal group = (GroupPrincipal)activeDirectoryGroups.First<Principal>();

                // make user member of group
                group.Members.Add(userEntry);

                // save changes
                group.Save();
                group.Dispose();
            }
            else
            {
                // throw exception to notify the group does not exists
                throw new ApplicationException("Domain group not found.");
            }

            // dispose the objects
            userEntry.Dispose();
            activeDirectoryGroups.Dispose();
        }

        /// <summary>
        ///     Make user account with given login name active or inactive
        /// </summary>
        /// <param name="loginName">user domain login name</param>
        /// <param name="status">true for enable false for disable</param>
        public void SetAccountStatus(string loginName, bool status)
        {
            try
            {
                // Find user entry by login name
                UserPrincipal userEntry = UserPrincipal.FindByIdentity(activeDirectoryDomain,
                    IdentityType.SamAccountName,
                    loginName);
                userEntry.Enabled = status;
                userEntry.Save();
                userEntry.Dispose();
            }
            catch (Exception ex)
            {
                throw new TerminalServerSetAccountStatusFailedException("Failed to set Account Status", ex);
            }
        }

        /// <summary>
        ///     Delete user account with login name 
        /// </summary>
        /// <param name="loginName">domain login name</param>
        public void DeleteAccount(string loginName)
        {
            // Find user entry by login name
            UserPrincipal userEntry = UserPrincipal.FindByIdentity(activeDirectoryDomain,
                IdentityType.SamAccountName,
                loginName);
            userEntry.Delete();
            userEntry.Dispose();
        }

        /// <summary>
        ///  destroying objects.
        /// </summary>
        public void Dispose()
        {
            this.activeDirectoryDomain.Dispose();
        }

        #endregion

        #region Private Methods
        /// <summary>
        ///     Searches the domain group as per filter criteria and returns all matching result.
        /// </summary>
        /// <param name="parGroupPrincipal">group pricinpal with search values to match for</param>
        /// <returns>group principals</returns>
        private PrincipalSearchResult<Principal> SearchGroups(GroupPrincipal parGroupPrincipal)
        {

            PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
            insPrincipalSearcher.QueryFilter = parGroupPrincipal;
            PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
            return results;
        }

        /// <summary>
        ///     Searches the domain users as per filter criteria and returns all matching result.
        /// </summary>
        /// <param name="parUserPrincipal">User principal with search values to match for</param>
        /// <returns></returns>
        private PrincipalSearchResult<Principal> SearchUsers(UserPrincipal parUserPrincipal)
        {
            PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher();
            insPrincipalSearcher.QueryFilter = parUserPrincipal;
            PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
            return results;
        }

        /// <summary>
        ///     List matching group names
        /// </summary>
        /// <param name="activeDirectoryDomain">domain context to search in</param>
        /// <param name="matchingName">group name pattern</param>
        private PrincipalSearchResult<Principal> ListGroupsByName(PrincipalContext activeDirectoryDomain, string matchingName)
        {
            GroupPrincipal insGroupPrincipal = new GroupPrincipal(activeDirectoryDomain);
            insGroupPrincipal.Name = matchingName; // "GlobalNetUsers";
            return this.SearchGroups(insGroupPrincipal);
        }

        /// <summary>
        ///     List mathcing users by description
        /// </summary>
        /// <param name="activeDirectoryDomain">domain context to search in</param>
        /// <param name="matchingName">group name pattern</param>
        private PrincipalSearchResult<Principal> ListUsersByDesciption(PrincipalContext activeDirectoryDomain, string matchingDescription)
        {
            UserPrincipal insUserPrincipal = new UserPrincipal(activeDirectoryDomain);
            insUserPrincipal.Description = matchingDescription; // "Employee of company *";
            return this.SearchUsers(insUserPrincipal);
        }
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.ActiverDirectoryDomain.Dispose();
        }

        #endregion
    }

    // Custom exception class
    public class TerminalServerLoginIdExistsException : ApplicationException
    {
        // Use the default ApplicationException constructors
        public TerminalServerLoginIdExistsException() : base() { }
        public TerminalServerLoginIdExistsException(string s) : base(s) { }
        public TerminalServerLoginIdExistsException(string s, Exception ex)
            : base(s, ex) { }
    }

    // Custom exception class
    public class InvalidPasswordException : ApplicationException
    {
        // Use the default ApplicationException constructors
        public InvalidPasswordException() : base() { }
        public InvalidPasswordException(string s) : base(s) { }
        public InvalidPasswordException(string s, Exception ex)
            : base(s, ex) { }
    }

    // Custom exception class
    public class TerminalServerSetAccountStatusFailedException : ApplicationException
    {
        // Use the default ApplicationException constructors
        public TerminalServerSetAccountStatusFailedException() : base() { }
        public TerminalServerSetAccountStatusFailedException(string s) : base(s) { }
        public TerminalServerSetAccountStatusFailedException(string s, Exception ex)
            : base(s, ex) { }
    }
}