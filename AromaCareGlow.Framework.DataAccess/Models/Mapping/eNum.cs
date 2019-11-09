//------------------------------------------------------------------------------ 
// <copyright file="eNum.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace AromaCareGlow.Framework.DataAccess.Models.Mapping
{
    /// <summary>
    ///     Types of stored procedure supported by the framework
    ///     
    ///     Created By : Majid Akhter             Modified By : Name
    ///     Create Date : 07/02/2008            Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    public enum DBProcedureType
    {
        /// <summary>
        ///     Select procedure using primary key
        /// </summary>
        SELECT,

        /// <summary>
        ///     Select procedure with multiple result
        /// </summary>
        SELECT_MULTIPLE,

        /// <summary>
        ///     Insert procedure
        /// </summary>
        INSERT,

        /// <summary>
        ///     Insert procedure name, It inserts multiple rows 
        ///     using table valued parameter.
        /// </summary>
        INSERT_MULTIPLE,

        /// <summary>
        ///     Update procedure
        /// </summary>
        UPDATE,

        /// <summary>
        ///     Delete procedure
        /// </summary>
        DELETE
    }

    /// <summary>
    ///     Different types of server used in the application, like truck load, DHL etc
    /// </summary>
    public enum ServerTypes
    {
        /// <summary>
        ///     GT Common Server
        /// </summary>
        Common = 0,

        /// <summary>
        ///     GT Truck load server
        /// </summary>
        TruckLoad = 1,

        /// <summary>
        ///     GT Enterprise database
        /// </summary>
        Enterprise = 2,

        /// <summary>
        ///     GT Warehouse database
        /// </summary>
        Warehouse = 3,

        /// <summary>
        /// GT Carrierrate database
        /// </summary>
        CarrierRate = 4,

        /// <summary>
        /// GT EDI database
        /// </summary>
        EDI = 5,

        /// <summary>
        /// GT EDI database
        /// </summary>
        Quote = 6
    }
}