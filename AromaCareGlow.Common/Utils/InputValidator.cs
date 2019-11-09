//------------------------------------------------------------------------------ 
// <copyright file="InputValidator.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AromaCareGlow.Common.Utils
{
    /// <summary>
    ///     A class for contianing all input validations. 
    ///     
    ///     Created By : Majid Akhter       Created Date : 07/21/2019	
    ///     Modified By : Name            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public static class InputValidator
    {
        #region Private Members
        #endregion

        #region Constructors

        #endregion

        #region Public Members

        /// <summary>
        ///     Validates the given string against the format specified for emails.
        /// </summary>
        /// <param name="inputEmail">email to check</param>
        /// <returns>true if email is in correct format else false</returns>
        public static bool IsEmail(string inputEmail)
        {
            string strRegex = string.Concat(
                  @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}",
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\",
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Validates the given string against the format specified for Http/Https url .
        /// </summary>
        /// <param name="inputEmail">url to check</param>
        /// <returns>true if url is in correct format else false</returns>
        public static bool IsUrl(string inputUrl)
        {
            string strRegex = @"((http|https)://|(www.))([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputUrl))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Validates the given string against the format specified for number.
        /// </summary>
        /// <param name="inputNumber">input to check</param>
        /// <returns>true if value given is number</returns>
        public static bool IsNumber(string inputNumber)
        {
            string strRegex = @"^\d*$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsFloat(string inputNumber)
        {
            string strRegex = @"^(\d\d*$)|(^\d\d*\.\d{1,2}$)|(^\d\d*)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Validates the given string against the format specified for number.
        /// </summary>
        /// <param name="inputNumber">number</param>
        /// <returns>true if value given is number</returns>
        public static bool IsNumbericDimension(string inputNumber)
        {
            string strRegex = @"^\d{2}[x]\d{2}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Function To test for Alphabets. .
        /// </summary>
        /// <param name="strToCheck">Returns true or false.</param>
        /// <returns>It returns true or false</returns>
        public static bool IsAlpha(string inputString)
        {
            string strRegex = @"^([a-zA-Z]+)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputString))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Function to test for string should not be empty.
        /// </summary>
        /// <param name="strToCheck">Returns true or false.</param>
        /// <returns>It returns true or false</returns>
        public static bool IsEmpty(string inputString)
        {
            if (!inputString.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Validator for verifying given sortcut key combination
        /// </summary>
        /// <param name="p">input sortcut key like CTRL+A, CTRL+ALT+A, CTRL+SHIFT+A etc.</param>
        /// <returns>return true if valid</returns>
        public static bool IsShortCutKey(string p)
        {
            Regex expression = new Regex("[CTRL+|ALT+|SHIFT+]{1,2}([0-9]|[A-Z])");
            Match match = expression.Match(p);
            return match.Success;
        }
        public static bool isFloat(string p)
        {
            throw new NotImplementedException();
        }

        public static bool isEmail(string p)
        {
            throw new NotImplementedException();
        }

        public static bool isNumber(string p)
        {
            throw new NotImplementedException();
        }

        public static bool isAlpha(string p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// check for login name with small letters or capitol letters with digits and without special characters.
        /// #,!,$,*,^,&,(,),%,=,+,|,\,/,?,',:,~,@
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isWindowLoginName(string p)
        {
            try
            {
                Regex expression = new Regex(@"^(?=.{6,})(?=.*[a-z]{0,})(?=.*[A-Z]{0,})(?=(.*[\d]){0,})(?!.*[#,!,$,*,^,&,(,),%,=,+,|,\,/,?,',:,~,@]).*$");
                Match match = expression.Match(p);
                return match.Success;
            }
            catch { return false; }
        }

        /// <summary>
        /// check for password with small letters or capitol letters with atleast one digits and one special characters and without space.
        /// #,!,$,*,^,&,.,<,>,_,-,(,),%,=,+,|,\,/,?,',:,~,@
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isStrongPassword(string p)
        {
            try
            {
                Regex expression = new Regex(@"^(?=.{8,})(?=.*[a-z]{0,})(?=.*[A-Z]{0,})(?=(.*[\d]){1,})(?=.*[#,!,$,*,^,&,.,<,>,_,-,(,),%,=,+,|,\,/,?,',:,~,@]{1,})(?!.*[ ]).*$");
                Match match = expression.Match(p);
                return match.Success;
            }
            catch { return false; }
        }
        #endregion

        #region Private Methods
        #endregion       
    }
}