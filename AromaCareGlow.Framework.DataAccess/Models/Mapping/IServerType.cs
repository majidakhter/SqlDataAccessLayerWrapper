//------------------------------------------------------------------------------ 
// <copyright file="IServerType.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

namespace AromaCareGlow.Framework.DataAccess.Models.Mapping
{
    /// <summary>
    ///     Base class for server types, Database server type property 
    ///     should be implemented in all derived classes.
    ///     
    ///     Created By : majid Akhter             	Create Date : 07/08/2008
    ///     Modified By : Name              Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public interface IServerType
    {
        /// <summary>
        ///     Gets or sets type of server attached 
        ///     with this dto or business model.
        /// </summary>
        ServerTypes DatabaseServerType
        {
            get;
            set;
        }
    }
}












