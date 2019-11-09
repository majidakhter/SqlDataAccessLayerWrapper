//------------------------------------------------------------------------------ 
// <copyright file="ServerManager.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using AromaCareGlow.Common.Constants.DataAccess;
using AromaCareGlow.Framework.Common.Models.DTO;
using AromaCareGlow.Framework.DataAccess.Models.Mapping;

namespace AromaCareGlow.Framework.Server.Facade
{
    /// <summary>
    ///     Manages connection string for different servers. It provides flexibility
    ///     for scale out and load balancing. Partitioning logic will be implemented here in future.
    ///     
    ///     Created By: Majid Akhter              Created Date: 07/07/2019
    ///     Modified By:                        Modified Date:
    /// </summary>
    public class ServerManager
    {
        #region Member Variables

        /// <summary>
        ///     Singleton instance of server manager
        /// </summary>
        private static ServerManager serverManagerInstance;

        /// <summary>
        ///     Collection of server machines, which contain connection string information.
        /// </summary>
        private List<ServerMachine> serverMachines;

        #endregion

        #region Constructor

        /// <summary>
        ///     Prevents a default instance of the {ServerManager} class from being created.
        /// </summary>
        private ServerManager()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets a singleton instance of server manager object.
        /// </summary>
        public static ServerManager Instance
        {
            get
            {
                // checks server manager object is null then create instance of that.
                if (serverManagerInstance == null)
                {
                    serverManagerInstance = new ServerManager();
                }

                return serverManagerInstance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get connection string  for specified server machine type
        /// </summary>
        /// <param name="serverType">
        ///     Type of server machine, it is an enum
        /// </param>
        /// <returns>
        ///     Connection string for specified server type.
        /// </returns>
        public string GetConnectionString(ServerTypes serverType)
        {
            string connectionString = null;

            // if server type is common then retrieve connection string from application config file
            if (serverType == ServerTypes.Common)
            {
#if !TEST
                connectionString = ConfigurationManager.ConnectionStrings[ConfigKeys.DATABASE_CONNECTION].ConnectionString;
#else
                connectionString = ConfigurationManager.ConnectionStrings[ConfigKeys.DATABASE_CONNECTION_TEST].ConnectionString;
#endif
            }
            else
            {
                // server list is null then retrieve server information from database.
                if (this.serverMachines == null || this.serverMachines.Count == 0)
                {
                    IBase baseFacde = new BaseFacade();
                    ServerMachine machines = new ServerMachine();
                    machines.DatabaseServerType = ServerTypes.Common;
                    this.serverMachines = baseFacde.GetModelsProcedure<ServerMachine>(machines);
                }

                // retrieves specified server information from collection using LINQ
                ServerMachine serverMachine = this.serverMachines.Single(p => p.ServerId == (short)serverType);

                if (serverMachine != null)
                {
                    connectionString = serverMachine.ServerValue;
                }
            }

            return connectionString;
        }

        #endregion
    }
}