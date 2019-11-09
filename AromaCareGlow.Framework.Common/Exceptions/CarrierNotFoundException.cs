//------------------------------------------------------------------------------ 
// <copyright file="CarrierNotFoundException.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;

namespace AromaCareGlow.Framework.Common.Exceptions
{
    /// <summary>
    ///     Custom exception class for carrier is not setup in netsuit db error.
    ///     
    ///     Created By : Majid Akhter       Created Date : 12/11/2019	
    ///     Modified By : Name            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public class CarrierNotFoundException : ApplicationException
    {
        #region Private Members
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor, initialize fields here.
        /// </summary>
        public CarrierNotFoundException()
        {
            // TODO, Add constructor logic here.
        }

        /// <summary>
        ///     Constructor, with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="ex">Inner exception.</param>
        public CarrierNotFoundException(string message, Exception ex)
            : base(message, ex)
        {
        }
        #endregion

        #region Public Members
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}

