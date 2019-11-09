//------------------------------------------------------------------------------ 
// <copyright file="ISQLTableType.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System.Collections.Generic;

namespace AromaCareGlow.Framework.DataAccess.Models.Mapping
{
    /// <summary>
    ///     Interface for implementing tablue valued data type functionality of MS SQL Server 2008.
    ///     
    ///     Created By: Majid Akhter                   Created Date:06/10/2019
    ///     Modified By:                            Modified Date: 
    ///     Comments: 
    ///     Modified By:
    /// </summary>
    public interface ISQLTableType
    {
        #region Properties

        /// <summary>
        ///     Gets or sets table valued input parameter, dataset table name 
        ///     will be the key, and name of user defined tabledata type in 
        ///     SQL server will be the value.
        /// </summary>
        Dictionary<string, DbParameter> TableValuedParameters
        {
            get;
            set;
        }

        #endregion
    }
}