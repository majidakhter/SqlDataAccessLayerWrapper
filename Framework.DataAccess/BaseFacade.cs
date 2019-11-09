//------------------------------------------------------------------------------ 
// <copyright file="BaseFacade.cs" company="AromaCareGlow LLP">
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
using AromaCareGlow.Framework.DataAccess.Factory.Accessors;
using AromaCareGlow.Framework.DataAccess.Models;
using AromaCareGlow.Framework.Server.Facade.DataAccess;
using AromaCareGlow.Framework.DataAccess.Models.Mapping;
using AromaCareGlow.Common.Utils;
//using AromaCareGlow.Framework.Common.Models.DTO.FMS;

namespace AromaCareGlow.Framework.Server.Facade
{
    /// <summary>
    ///     Common Facade for CRUD operations (Create, Retrieve, Update and Delete). 
    ///     CRUD operation can be done using stored procedure or direct sql statements.
    ///     All the methods in this class are generic methods therefore we can use 
    ///     these methods for CRUD operations of any class which implements IModel interface.
    ///     Created By :    Majid Akhter                       Modified By:
    ///     Created Date:   10/23/2019                 Modified Date:
    /// </summary>
    public class BaseFacade : IBase
    {
        #region CRUD Methods

        #region SQL Methods

        /// <summary>
        ///     Save the data in a persistant storage. 
        ///     If the given object is new one then create a new record else update existing record.
        ///     It is a generaic method, it can be used to save any of the objects which implements
        ///     Framework.Common.Models.IModel interface.
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="dtoModel">
        ///     A Framework.Common.Models object that contins data to be saved.
        /// </param>
        /// <returns>
        ///     A boolean value which indicating save operation is succesful or not.
        /// </returns>
        public bool Save<T>(T dtoModel) where T : IModel
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(dtoModel.DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            bool isSuccess = false;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                // If the given object is new one then create a new record in database
                // else update existing record.
                if (dtoModel.IsNew)
                {
                    // Create a  new record in database, Insert method of data accessor class 
                    // will generate sql statements on the fly from custom attributes of dto model.                    
                    dtoModel = (T)dataAccessor.Insert(dtoModel);
                    if (!dtoModel.IsNew)
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    // Update existing record in database, Update method of data accessor class 
                    // will generate sql statements on the fly from custom attributes of dto model.                    
                    dtoModel = (T)dataAccessor.Update(dtoModel);
                    isSuccess = true;
                }
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return isSuccess;
        }

        /// <summary>
        ///     Retrieve an entity form the persistent storage using the primary key.
        /// </summary>
        /// <typeparam name="T">
        ///      Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="primaryKey">
        ///     Primary key of the entity which is used to identify the entity.
        /// </param>
        /// <returns>
        ///     A Framework.Common.Models object which contains requested entity.
        /// </returns>
        public T GetModel<T>(int primaryKey) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(new T().DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            T dataModel;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                // call select method for retrieving requested entity from database and fill to the dto model. 
                dataModel = (T)dataAccessor.Select(primaryKey);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dataModel;
        }

        /// <summary>
        ///     Retrieve a collection of entities based on the input criterias
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="fieldNames">
        ///     A array of column names which is used to create filter conditions.
        /// </param>
        /// <param name="fieldValues">
        ///     A array of field values which is used to create filter conditions.
        /// </param>
        /// <returns>
        ///     A collection of entities.
        /// </returns>
        public List<T> GetModels<T>(string[] fieldNames, string[] fieldValues) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(new T().DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            List<T> dataModels = null;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                dataModels = dataAccessor.SelectMultiple<T>(fieldNames, fieldValues);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dataModels;
        }

        /// <summary>
        ///     Delete the entry from persistant storage.
        ///     It is a generic method, it can be used to delete any of the 
        ///     objects which implements Framework.Common.Models.IModel interface.
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="primaryKey">
        ///     Primary key of the entity which is used to identify the entity.
        /// </param>
        /// <returns>
        ///     A boolean value indicating delete operation is succesful or not.
        /// </returns>
        public bool Delete<T>(int primaryKey) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(new T().DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            bool isSuccess = false;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                dataAccessor.Delete(primaryKey);
                isSuccess = true;
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return isSuccess;
        }

        #endregion

        #region Stored Procedure Methods

        /// <summary>
        ///     Save the data in a persistant storage using stored procedure. 
        ///     If the given object is new one then create a new record else update existing record.
        ///     It is a generic method, it can be used to save any of the objects which implements
        ///     Framework.Common.Models.IModel interface.
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="dtoModel">
        ///     A Framework.Common.Models object that contins data to be saved.
        /// </param>
        /// <returns>
        ///     A boolean value which indicating save operation is succesful or not.
        /// </returns>
        public bool SaveProcedure<T>(T dtoModel) where T : IModel
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(dtoModel.DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            bool isSuccess = false;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                // If the given object is new one then create a new record in database
                // else update existing record.
                if (dtoModel.IsNew)
                {
                    // Create a  new record in database, Insert method of data accessor class 
                    // will generate sql command object and parameters on the fly from custom attributes of dto model.                    
                    dtoModel = (T)dataAccessor.InsertProcedure(dtoModel);
                    if (dtoModel != null && (!dtoModel.IsNew))
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    // Update existing record in database, Update method of data accessor class 
                    // will generate sql command object and parameters on the fly from custom attributes of dto model.                    
                    dtoModel = (T)dataAccessor.UpdateProcedure(dtoModel);
                    isSuccess = true;
                }
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
                else
                {
                    throw sx;
                }
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return isSuccess;
        }

        /// <summary>
        ///     Bulk insert collection of record to the database using sql server table valued parameter.
        /// </summary>    
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="modelCollection">
        ///     A collection objects which implements imodel for bulk insert.
        /// </param>
        /// <returns>
        ///     A boolean value indicating insert opertation is successful or not.
        /// </returns>
        public bool InsertTableValuedProcedure<T>(List<T> modelCollection) where T : IModel, new()
        {
            return true;
        }

        /// <summary>
        /// Bulk insert collection of record to the database using sql server table valued parameter.
        /// </summary>
        /// <typeparam name="T">
        ///  Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="modelCollection">
        ///  Implements imodel for bulk insert.
        /// </param>
        /// <param name="dtProduct">
        ///  A collection objects which implements imodel for bulk insert.
        /// </param>
        /// <returns></returns>
        public bool InsertTableProcedure<T>(List<T> modelCollection, DataTable dtProduct, T modeldt) where T : IModel, new()
        {

            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type
            string connectionString = ServerManager.Instance.GetConnectionString(modeldt.DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);
            IDbTransaction transaction = null;
            bool isSuccess = false;

            // get your connection string         
            // connect to SQL
            using (SqlConnection sqlconnection =
            new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // create common data accessor for doing database operations.
                    IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T), transaction);

                    //transaction = connection.BeginTransaction();

                    ///     Hash table for model mapping 
                    ModelDataMap modelDataMap = dataAccessor.InsertTableValuedProcedure<T>(modelCollection);

                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        sqlconnection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );

                    // set the destination table name
                    bulkCopy.DestinationTableName = modelDataMap.TableName;
                    sqlconnection.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dtProduct);

                    connection.Close();
                    isSuccess = true;

                    //if (isSuccess)
                    //{
                    //    transaction.Commit();
                    //}
                    //else
                    //{
                    //    transaction.Rollback();
                    //}

                    //transaction = null;
                }
                finally
                {
                    // if transaction exits then rollback transaction
                    //if (transaction != null)
                    //{
                    //    transaction.Rollback();
                    //}

                    // Close the Connection if Opened
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return isSuccess;
        }

        /// <summary>
        ///     Retrieve an entity from the persistent storage using the primary key.
        /// </summary>
        /// <typeparam name="T">
        ///      Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="primaryKey">
        ///     Primary key of the entity which is used to identify the entity.
        /// </param>
        /// <returns>
        ///     A Framework.Common.Models object which contains requested entity.
        /// </returns>
        public T GetModelProcedure<T>(int primaryKey) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type            
            string connectionString = ServerManager.Instance.GetConnectionString(new T().DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            T dataModel;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                // call select method for retrieving requested entity from database and fill to the dto model. 
                dataModel = (T)dataAccessor.SelectProcedure(primaryKey);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dataModel;
        }

        /// <summary>
        ///     Retrieve an entity from the persistant storage using the primary key.
        /// </summary>
        /// <typeparam name="T">
        ///      Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="model">
        ///     A model object which contains filter conditions
        /// </param>
        /// <returns>
        ///     A Framework.Common.Models object which contains requested entity.
        /// </returns>
        public T GetModelProcedure<T>(T model) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type            
            string connectionString = ServerManager.Instance.GetConnectionString(model.DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                // call select method for retrieving requested entity 
                // from database and fill to the dto model. 
                model = (T)dataAccessor.SelectProcedure(model);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return model;
        }

        /// <summary>
        ///     Retrieve a collection of entities based on the input criterias using stored procedure 
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="model">
        ///     A model object which contains filter conditions.
        /// </param>
        /// <returns>
        ///     A collection of entities.
        /// </returns>
        public List<T> GetModelsProcedure<T>(T model) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type           
            string connectionString = ServerManager.Instance.GetConnectionString(model.DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            List<T> dataModels = null;
            try
            {

                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                dataModels = dataAccessor.SelectMultipleFromProcedure<T>(model);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return dataModels;
        }

        /// <summary>
        ///     Delete the entry from persistent storage using stored procedure.
        ///     It is a generic method, it can be used to delete any of the 
        ///     objects which implements Framework.Common.Models.IModel interface.
        /// </summary>
        /// <typeparam name="T">
        ///     Any type which implements Framework.Common.Models.IModel interface.
        /// </typeparam>
        /// <param name="primaryKey">
        ///     Primary key of the entity which is used to identify the entity.
        /// </param>
        /// <returns>
        ///     A boolean value indicating delete operation is succesful or not.
        /// </returns>
        public bool DeleteProcedure<T>(int primaryKey) where T : IModel, new()
        {
            IFrameworkDataAccessFactory factory = DbInstance.CurrentInstance;

            // retrieves connection string of specified server type            
            string connectionString = ServerManager.Instance.GetConnectionString(new T().DatabaseServerType);
            IDbConnection connection = factory.CreateConnection(connectionString);

            bool isSuccess = false;
            try
            {
                connection.Open();

                // create common data accessor for doing database operations.
                IDataAccessor dataAccessor = factory.CreateAccessor(connection, typeof(T));

                isSuccess = dataAccessor.DeleteProcedure(primaryKey);
            }
            finally
            {
                // Close the Connection if Opened
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return isSuccess;
        }

        #endregion

        #endregion
    }
}