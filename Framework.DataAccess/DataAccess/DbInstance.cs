//------------------------------------------------------------------------------ 
// <copyright file="DbInstance.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using AromaCareGlow.Common.Constants.DataAccess;
using AromaCareGlow.Framework.DataAccess.Factory;

namespace AromaCareGlow.Framework.Server.Facade.DataAccess
{
    /// <summary>
    ///     Create instance of different framework factory objects, like sql, oracle etc
    /// </summary>
    public class DbInstance
    {
        #region Static Member Variables

        /// <summary>
        ///     Static instance of the SqlFrameworkDataAccessFactory class
        /// </summary>
        private static IFrameworkDataAccessFactory currentInstance;

        #endregion

        #region Private Constructor

        /// <summary>
        ///     Private constructor for singleton
        /// </summary>
        private DbInstance()
        {
        }

        #endregion

        #region Static Methods

        /// <summary>
        ///		Gets or sets current instance of framework data access factory
        /// </summary>
        public static IFrameworkDataAccessFactory CurrentInstance
        {
            get
            {
                // if current instance is null create factory object using 
                // the information in application config
                if (currentInstance == null)
                {
                    switch (ConfigKeys.DATABASETYPE)
                    {
                        case (int)ConfigKeys.DatabaseType.SqlServer:
                            currentInstance = new SqlCustomFrameworkDataAccessFactory();
                            break;
                    }
                }

                return currentInstance;
            }

            set
            {
                currentInstance = value;
            }
        }

        #endregion
    }
}