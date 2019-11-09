//------------------------------------------------------------------------------ 
// <copyright file="IModel.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using AromaCareGlow.Framework.DataAccess.Models.Mapping;

namespace AromaCareGlow.Framework.DataAccess.Models
{
    /// <summary>
    /// This interface should be implemented by all models. 
    /// It does not specify any methods that need to be implemented.
    /// Its sole purpose is to give all model implementations a common type.
    /// </summary>
    public interface IModel : IServerType
    {
        /// <summary>
        ///     Gets a value indicating whether current object 
        ///     is a new object or existing object. 
        /// </summary>
        bool IsNew
        {
            get;
        }
    }
}