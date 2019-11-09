﻿//------------------------------------------------------------------------------ 
// <copyright file="DbParameter.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System.Data;

namespace AromaCareGlow.Framework.DataAccess.Models.Mapping
{
    /// <summary>
    ///     Describes input parameter of stored procedure. 
    ///     Parameters can be input or output.
    ///     
    ///     Created By: Majid Akhter               Created Date:06/10/2008
    ///     Modified By:                        Modified Date:
    /// </summary>    
    public class DbParameter // <T>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets parameter name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets parameter data type (Base dbtype)
        /// </summary>
        public DbType DataType
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets stored procedure parameter direction, It can be Input or output
        /// </summary>
        public ParameterDirection SPParameterDirection
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets value of input parameter.
        /// </summary>
        public object ParameterValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size of the parameter value.
        /// </summary>
        public int Size
        {
            get;
            set;
        }
        #endregion
    }
}









