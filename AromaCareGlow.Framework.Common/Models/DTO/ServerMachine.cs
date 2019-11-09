//------------------------------------------------------------------------------
// <copyright file="ServerMachine.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using AromaCareGlow.Framework.DataAccess.Models;
using AromaCareGlow.Framework.DataAccess.Models.Mapping;

namespace AromaCareGlow.Framework.Common.Models.DTO
{
    /// <summary>
    ///     Represents server machines table with server type
    ///    
    ///     Created By : Majid Akhter              Create Date : 07/06/2019
    ///     Modified By : Name                  Modified Date : mm/dd/yyyy
    ///     ----------------------------------------------------------
    ///     Change Comment
    ///     ----------------------------------------------------------
    /// </summary>
    [TableMapping("dbo.ServerMachines", "ServerId")]
    [SelectMultipleProcedureMapping("dbo.spGetServers")]
    public class ServerMachine : IModel
    {
        #region Member Variables

        /// <summary>
        ///     Type of server which this object is attached.
        /// </summary>
        private ServerTypes databaseServerType;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create instance of server type object.
        /// </summary>
        public ServerMachine()
        {
            // initialize database server type object
            this.databaseServerType = ServerTypes.Common;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the server id, primary key of the table
        /// </summary>
        [ColumnMapping("ServerId", true)]
        public short ServerId
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets name of the server machine
        /// </summary>
        [ColumnMapping("ServerName", false)]
        public string ServerName
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets value for server machine, it can be
        ///     connection string, web server connection information etc
        /// </summary>
        [ColumnMapping("ServerValue", false)]
        public string ServerValue
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether server machine is available.
        /// </summary>
        [ColumnMapping("IsAvailable", false)]
        public bool IsAvailable
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets server type id.
        /// </summary>
        [ColumnMapping("ServerTypeId", false)]
        public short ServerTypeId
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets type of server.
        /// </summary>
        [ColumnMapping("ServerType", true)]
        public string ServerMachineType
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets a value indicating whether it is a non persistent model.
        /// </summary>
        public bool IsNew
        {
            get
            {
                return this.ServerId == 0;
            }
        }

        /// <summary>
        ///     Gets or sets type of server attached
        ///     with this dto or business model.
        /// </summary>
        public ServerTypes DatabaseServerType
        {
            get
            {
                return this.databaseServerType;
            }

            set
            {
                this.databaseServerType = value;
            }
        }

        #endregion
    }
}