//------------------------------------------------------------------------------ 
// <copyright file="SqlCustomFrameworkFactory.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System.Data;
using System.Data.SqlClient;

using AromaCareGlow.Framework.DataAccess.Factory;
using AromaCareGlow.Framework.DataAccess.Factory.Accessors;
using AromaCareGlow.Framework.Server.Facade.DataAccess.Accessors;

namespace AromaCareGlow.Framework.Server.Facade.DataAccess
{
    /// <summary>
    ///		This class implements framework data accessor methods for MS SQL Server database.
    ///		It creates database connections and various accessor classes
    /// </summary>
    public class SqlCustomFrameworkDataAccessFactory : SqlFrameworkDataAccessFactory
    {
        #region Custom Accessor

        /// <summary>
        ///     Create accessors for custom activities, It is a genetic method.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of custom accessor, type should implement ICustom accessor interface.
        /// </typeparam>
        /// <param name="connection">
        ///     Connection object for database operations
        /// </param>
        /// <returns>
        ///     Accessor specified in generic type
        /// </returns>
        public override T CreateCustomAccessor<T>(IDbConnection connection)
        {
            ICustomAccessor customAccessor = null;

            // Checks for type of custom accessor interface given and 
            // create sql accessors according to that
            if (typeof(T) == typeof(ICustomDataAccessor))
            {
                // create sql custom accessor
                customAccessor = new SqlCustomDataAccessor((SqlConnection)connection);
            }
            else if (typeof(T) == typeof(IBulkDataAccessor))
            {
                // create bulk accessors
                customAccessor = new SqlBulkDataAccessor();
            }

            return (T)customAccessor;
        }

        /// <summary>
        ///     Create accessors for custom activities, It is a genetic method.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of custom accessor, type should implement ICustom accessor interface.
        /// </typeparam>
        /// <param name="transaction">
        ///     Connection object for database operations
        /// </param>
        /// <returns>
        ///     Accessor specified in generic type
        /// </returns>
        public override T CreateCustomAccessor<T>(IDbTransaction transaction)
        {
            ICustomAccessor customAccessor = null;

            // Checks for type of custom accessor interface given and 
            // create sql accessors according to that
            if (typeof(T) == typeof(ICustomDataAccessor))
            {
                // create sql custom accessor
                customAccessor = new SqlCustomDataAccessor((SqlTransaction)transaction);
            }
            else if (typeof(T) == typeof(IBulkDataAccessor))
            {
                // create bulk accessors
                customAccessor = new SqlBulkDataAccessor();
            }

            return (T)customAccessor;
        }

        #endregion
    }
}