    //------------------------------------------------------------------------------ 
    // <copyright file="CustomFacade.cs" company="AromaCareGlow LLP">
    //     Copyright (c) AromaCareGlow LLP.  All rights reserved.
    // </copyright>
    //------------------------------------------------------------------------------ 

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using AromaCareGlow.Common.Constants.DataAccess;
    using AromaCareGlow.Framework.Common.Exceptions;
    using AromaCareGlow.Framework.DataAccess.Factory;
    using AromaCareGlow.Framework.DataAccess.Models.Mapping;
    using AromaCareGlow.Framework.Server.Facade.DataAccess;
    using AromaCareGlow.Framework.Server.Facade.DataAccess.Accessors;

    namespace AromaCareGlow.Framework.Server.Facade
    {
        /// <summary>
        ///     Interface for CRUD operations (Create, Retrieve, Update and Delete) using typed dataset. 
        ///     and other custom operations.All the methods defined in this interface are generic methods 
        ///     therefore we can use these methods for CRUD operations of any typed dataset 
        ///     object which implements IDataSet interface.
        /// 
        ///     Created By :    Majid Akhter                       Created Date:   06/10/2019
        ///     Modified By:                      Modified Date: 
       
        ///     ----------------------------------------------------------
        ///     Throw the New Custom Exception.
        ///     ExecuteStoredProcedure() added a catch exception.
        ///     ----------------------------------------------------------
        /// </summary>
        public class CustomFacade : ICustom
        {
            /// <summary>
            ///     Generic data retrieval method for datasets, It fill result to typed dataset
            /// </summary>
            /// <typeparam name="T">
            ///     Typed dataset that should implement IDataSet interface.
            /// </typeparam>
            /// <param name="typedDataSet">
            ///     Typed dataset instance, stored procedure name property 
            ///     of this instance should have valid data.
            /// </param>      
            /// <returns>
            ///     A typed dataset instance, filled with query execution result.
            /// </returns>
            public T GetDataSet<T>(T typedDataSet) where T : DataSet, IDataSet
            {
                // checks for stored procedure name in given dataset, 
                // if not specified then throw exception
                if (string.IsNullOrEmpty(typedDataSet.StoredProcedureName))
                {
                    throw new MissingMemberException("Stored procedure name not specified in given dataset instance");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(typedDataSet.DatabaseServerType);
                IDbConnection connection = factory.CreateConnection(connectionString);

                try
                {
                    connection.Open();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(connection);

                    // call generic get method.
                    typedDataSet = customAccessor.GetDataSet<T>(typedDataSet);
                }
                finally
                {
                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return typedDataSet;
            }

            /// <summary>
            ///     Save data in the data set in persistent storage, it use table valued 
            ///     data type functionality SQL Server 2008.
            /// </summary>
            /// <typeparam name="T">
            ///     Typed dataset that should implement IDataSet interface.
            /// </typeparam>
            /// <param name="typedDataSet">
            ///     Typed dataset instance, stored procedure name property 
            ///     of this instance should have valid data.
            /// </param>
            /// <returns>
            ///     Returns number of rows affected
            /// </returns>
            public int InsertSQLTableType<T>(T typedDataSet) where T : DataSet, IDataSet, ISQLTableType
            {
                // checks for stored procedure name in given dataset, 
                // if not specified then throw exception
                if (string.IsNullOrEmpty(typedDataSet.StoredProcedureName))
                {
                    throw new MissingMemberException("Stored procedure name not specified in given dataset instance");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(typedDataSet.DatabaseServerType);
                IDbConnection connection = factory.CreateConnection(connectionString);
                IDbTransaction transaction = null;
                int result = 0;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(transaction);

                    // call generic get method.
                    result = customAccessor.InsertSQLTableType<T>(typedDataSet);
                    transaction.Commit();
                    transaction = null;
                }
                catch (SqlException sx)
                {
                    if (sx.Number == DatabaseErrorConstants.TIMESTAMP_MISMATCH_ERROR)
                    {
                        // Throw custom exception
                        throw new TimeStampMismatchException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.HAZMAT_PACKET_NOT_RECEIVED_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierPacketNotAvailableException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.CARRIER_CODE_ALREADY_EXIST_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierCodeAlreadyExistException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.CARRIER_INSURANCE_EXPIRED_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierInsuranceExpiredException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.CARRIER_INACTIVE_ERROR)
                    {
                        // Throw custom exception
                        throw new InActiveCarrierException(sx.Message, sx);
                    }
                    else
                    {
                        throw sx;
                    }
                }
                finally
                {
                    // if transaction exits then rollback transaction
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return result;
            }

            /// <summary>
            ///     Save data in the data set in persistent storage, it use table valued 
            ///     data type functionality SQL Server 2008.
            /// </summary>
            /// <typeparam name="T">
            ///     Typed dataset that should implement IDataSet interface.
            /// </typeparam>
            /// <param name="typedDataSet">
            ///     Typed dataset instance, stored procedure name property 
            ///     of this instance should have valid data.
            /// </param>
            /// <returns>
            ///     Returns number of rows affected
            /// </returns>
            public T InsertSelectSQLTableType<T>(T typedDataSet, T outputTypedDataSet) where T : DataSet, IDataSet, ISQLTableType
            {
                // checks for stored procedure name in given dataset, 
                // if not specified then throw exception
                if (string.IsNullOrEmpty(typedDataSet.StoredProcedureName))
                {
                    throw new MissingMemberException("Stored procedure name not specified in given dataset instance");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(typedDataSet.DatabaseServerType);
                IDbConnection connection = factory.CreateConnection(connectionString);
                IDbTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(transaction);

                    // call generic get method.
                    outputTypedDataSet = customAccessor.InsertSelectSQLTableType<T>(typedDataSet, outputTypedDataSet);
                    transaction.Commit();
                    transaction = null;
                }
                catch (SqlException sx)
                {
                    if (sx.Number == DatabaseErrorConstants.TIMESTAMP_MISMATCH_ERROR)
                    {
                        // Throw custom exception
                        throw new TimeStampMismatchException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.HAZMAT_PACKET_NOT_RECEIVED_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierPacketNotAvailableException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.CARRIER_CODE_ALREADY_EXIST_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierCodeAlreadyExistException(sx.Message, sx);
                    }
                    else if (sx.Number == DatabaseErrorConstants.CARRIER_INSURANCE_EXPIRED_ERROR)
                    {
                        // Throw custom exception
                        throw new CarrierInsuranceExpiredException(sx.Message, sx);
                    }
                    else
                    {
                        throw sx;
                    }
                }
                finally
                {
                    // if transaction exits then rollback transaction
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return outputTypedDataSet;
            }


            public int ExecuteStoredProcedure(string storedProcName, List<DbParameter> inputParameters, ServerTypes serverType)
            {
                // checks for stored procedure name  
                // if not specified then throw exception
                if (string.IsNullOrEmpty(storedProcName))
                {
                    throw new MissingMemberException("Stored procedure name not specified.");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(serverType);
                IDbConnection connection = factory.CreateConnection(connectionString);
                IDbTransaction transaction = null;
                int result = 0;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(transaction);

                    result = customAccessor.ExecuteStoredProcedure(storedProcName, inputParameters);
                    transaction.Commit();
                    transaction = null;
                }
                catch (SqlException sx)
                {
                    if (sx.Number == DatabaseErrorConstants.DATA_MISMATCH_ERROR)
                    {
                        // Throw custom exception
                        throw new DataMismatchException(sx.Message, sx);
                    }
                    else
                    {

                        throw sx;
                    }
                }
                finally
                {
                    // if transaction exits then rollback transaction
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return result;
            }


            public DataSet GetDataSet(string storedProcName, List<DbParameter> inputParameters, ServerTypes serverType)
            {
                // checks for stored procedure name  
                // if not specified then throw exception
                if (string.IsNullOrEmpty(storedProcName))
                {
                    throw new MissingMemberException("Stored procedure name not specified.");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(serverType);
                IDbConnection connection = factory.CreateConnection(connectionString);
                IDbTransaction transaction = null;
                DataSet result = new DataSet();
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(transaction);

                    result = customAccessor.GetDataSet(storedProcName, inputParameters);
                    transaction.Commit();
                    transaction = null;
                }
                catch (SqlException sx)
                {
                    if (sx.Number == DatabaseErrorConstants.DATA_MISMATCH_ERROR)
                    {
                        // Throw custom exception
                        throw new DataMismatchException(sx.Message, sx);
                    }
                    else
                    {

                        throw sx;
                    }
                }
                finally
                {
                    // if transaction exits then rollback transaction
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }

                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return result;
            }

            /// <summary>
            ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the output parameters
            /// </summary>
            /// <typeparam name="T">
            ///     Typed dataset that should implement IDataSet interface.
            /// </typeparam>
            /// <param name="typedDataSet">
            ///     Typed dataset instance, stored procedure name property 
            ///     of this instance should have valid data.
            /// </param>      
            /// <returns>
            ///     A typed dataset instance, filled with query execution result.
            /// </returns>
            public T GetDataSetWithParameters<T>(T typedDataSet) where T : DataSet, IDataSet
            {
                return GetDataSetWithParameters<T>(typedDataSet, false);
            }

            /// <summary>
            ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the output parameters
            /// </summary>
            /// <typeparam name="T">
            ///     Typed dataset that should implement IDataSet interface.
            /// </typeparam>
            /// <param name="typedDataSet">
            ///     Typed dataset instance, stored procedure name property 
            ///     of this instance should have valid data.
            /// </param>      
            /// <param name="forceOutputParameter">
            ///     If the given stored procedure does not return any record(s) also, the output parameter will be retrieved.
            ///     <para>
            ///     Basically, output parameter is forced to be retrieved.
            ///     </para>
            /// </param>
            /// <returns>
            ///     A typed dataset instance, filled with query execution result.
            /// </returns>
            public T GetDataSetWithParameters<T>(T typedDataSet, Boolean forceOutputParameter) where T : DataSet, IDataSet
            {
                // checks for stored procedure name in given dataset, 
                // if not specified then throw exception
                if (string.IsNullOrEmpty(typedDataSet.StoredProcedureName))
                {
                    throw new MissingMemberException("Stored procedure name not specified in given dataset instance");
                }

                // create instance of data access factory
                IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

                // create connection object for database access.
                string connectionString = ServerManager.Instance.GetConnectionString(typedDataSet.DatabaseServerType);
                IDbConnection connection = factory.CreateConnection(connectionString);

                try
                {
                    connection.Open();

                    // create custom accessor instance
                    ICustomDataAccessor customAccessor = factory.CreateCustomAccessor<ICustomDataAccessor>(connection);

                    // call generic get method.
                    typedDataSet = customAccessor.GetDataSetWithParameters<T>(typedDataSet, forceOutputParameter);
                }
                finally
                {
                    // close connection if it is open
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return typedDataSet;
            }
        }
    }










   







