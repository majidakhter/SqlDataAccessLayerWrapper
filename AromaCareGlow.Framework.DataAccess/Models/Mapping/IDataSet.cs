//------------------------------------------------------------------------------ 
// <copyright file="IDataSet.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System.Collections.Generic;

namespace AromaCareGlow.Framework.DataAccess.Models.Mapping
{
    /// <summary>
    ///     This interface should be implemented all dataset.
    /// </summary>
    public interface IDataSet : IServerType
    {
        #region Properties

        /// <summary>
        ///     Gets or sets select stored procedure name
        /// </summary>
        string StoredProcedureName
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets input parameters of stored procedure
        /// </summary>
        List<DbParameter> InputParams
        {
            get;
            set;
        }

        #endregion
    }
}