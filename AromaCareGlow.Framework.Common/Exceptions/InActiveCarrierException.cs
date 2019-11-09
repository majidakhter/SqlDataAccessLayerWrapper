using System;
using System.Collections.Generic;
using System.Text;

namespace AromaCareGlow.Framework.Common.Exceptions
{
    public class InActiveCarrierException:ApplicationException
    {
        #region Private Members
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor, initialize fields here.
        /// </summary>
        public InActiveCarrierException()
        {
            // TODO, Add constructor logic here.
        }

        /// <summary>
        ///     Constructor, with parameters.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="ex">Inner exception.</param>
        public InActiveCarrierException(string message, Exception ex)
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
