//------------------------------------------------------------------------------ 
// <copyright file="SqlCustomDataAccessor.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using AromaCareGlow.Framework.DataAccess.Models.Mapping;

namespace AromaCareGlow.Framework.Server.Facade.DataAccess.Accessors
{
    /// <summary>
    ///     It provides methods for CRUD operations using typed datasets.
    ///     It implements Icustom accessor methods.
    ///     Timeout period is set for the command object.
    ///     GetDataSetWithParameters() mrthod is modified to set the dbtype and size.
    ///     
    ///     Created By: Majid Akhter               Created Date: 06/20/2019
    ///     Modified BY:             Modified Date:
 
    /// </summary>
    public class SqlCustomDataAccessor : ICustomDataAccessor
    {
        #region Member Variables

        /// <summary>
        ///     Sql Connection object for database operations
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        ///     Transaction object to maintain integrity.
        /// </summary>
        private SqlTransaction transaction;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create new instance of custom data accessor and 
        ///     initialize connection and transaction.
        /// </summary>
        /// <param name="conn">
        ///     SqlCOnnection object.
        /// </param>
        /// <param name="tran">
        ///     Sql transaction for maintaining database integrity.
        /// </param>
        public SqlCustomDataAccessor(SqlConnection conn, SqlTransaction tran)
        {
            this.connection = conn;
            this.transaction = tran;
        }

        /// <summary>
        ///     Create new instance of custom data accessor and 
        ///     initialize connection and transaction.
        /// </summary>
        /// <param name="conn">
        ///     SqlCOnnection object.
        /// </param>
        public SqlCustomDataAccessor(SqlConnection conn)
        {
            this.connection = conn;
            this.transaction = null;
        }

        /// <summary>
        ///     Create new instance of custom data accessor and 
        ///     initialize connection and transaction.
        /// </summary>
        /// <param name="transaction">
        ///     SqlTransaction object.
        /// </param>
        public SqlCustomDataAccessor(SqlTransaction transaction)
        {
            this.connection = transaction.Connection;
            this.transaction = transaction;
        }

        #endregion

        #region Methods

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
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(typedDataSet.StoredProcedureName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.CommandTimeout = 150;

            // iterate through each input parameter list and create sql parameter object.
            if (typedDataSet.InputParams != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in typedDataSet.InputParams)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.Value = dbParam.ParameterValue;
                    command.Parameters.Add(sqlParam);
                }
            }

            // execute stored procedure and fill result to data set 
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // data set has one or more tables then map that with adapter default table settings
                if (typedDataSet.Tables != null && typedDataSet.Tables.Count > 0)
                {
                    // map first table in data set with adapter table
                    adapter.TableMappings.Add("Table", typedDataSet.Tables[0].TableName);

                    // iterate trough each table in the dataset.
                    for (int tableIndex = 1; tableIndex < typedDataSet.Tables.Count; tableIndex++)
                    {
                        adapter.TableMappings.Add(("Table" + tableIndex), typedDataSet.Tables[tableIndex].TableName);
                    }
                }

                // fill dataset using adapter
                adapter.Fill(typedDataSet);
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
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(typedDataSet.StoredProcedureName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;

            // iterate through each input parameter list and create sql parameter object.
            if (typedDataSet.InputParams != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in typedDataSet.InputParams)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.Direction = dbParam.SPParameterDirection;
                    if (sqlParam.Direction != ParameterDirection.Output)
                    {
                        sqlParam.Value = dbParam.ParameterValue;
                    }

                    command.Parameters.Add(sqlParam);
                }
            }

            // check for any table valued type input type exists 
            if (typedDataSet.TableValuedParameters != null)
            {
                // iterate through each item in table valued parameter list.
                foreach (KeyValuePair<string, DbParameter> keyValue in typedDataSet.TableValuedParameters)
                {
                    // create new sql parameter and assign data table to parameter
                    SqlParameter sqlParam = command.Parameters.AddWithValue(
                        keyValue.Value.Name,
                        typedDataSet.Tables[keyValue.Key]);

                    // set sql db type and sql server user defined table data type name.
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    sqlParam.TypeName = keyValue.Value.ParameterValue.ToString();
                }
            }

            // execute stored procedure.
            int result = command.ExecuteNonQuery();

            // checks number of records affected by the query
            if (result > 0)
            {
                if (typedDataSet.InputParams != null)
                {
                    // retrieve value of output parameter from command object 
                    // and assign to the dbparameter object.
                    foreach (DbParameter outputParameter in typedDataSet.InputParams)
                    {
                        // checks parameter is input or output.
                        if (outputParameter.SPParameterDirection == ParameterDirection.Output
                            || outputParameter.SPParameterDirection == ParameterDirection.InputOutput)
                        {
                            outputParameter.ParameterValue = command.Parameters[outputParameter.Name].Value;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Save data in the data set in persistent storage and 
        ///     to fetch the new table values in the type dataset, 
        ///     it use table valued data type functionality SQL Server 2008.
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet interface.
        /// </typeparam>
        /// <param name="typedDataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///    A typed dataset instance, filled with query execution result.
        /// </returns>
        public T InsertSelectSQLTableType<T>(T typedDataSet, T outputTypedDataSet) where T : DataSet, IDataSet, ISQLTableType
        {
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(typedDataSet.StoredProcedureName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;

            //T newtypeDataSet=typedDataSet;

            //newtypeDataSet.Clear();

            // iterate through each input parameter list and create sql parameter object.
            if (typedDataSet.InputParams != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in typedDataSet.InputParams)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.Direction = dbParam.SPParameterDirection;
                    if (sqlParam.Direction != ParameterDirection.Output)
                    {
                        sqlParam.Value = dbParam.ParameterValue;
                    }

                    command.Parameters.Add(sqlParam);
                }
            }

            // check for any table valued type input type exists 
            if (typedDataSet.TableValuedParameters != null)
            {
                // iterate through each item in table valued parameter list.
                foreach (KeyValuePair<string, DbParameter> keyValue in typedDataSet.TableValuedParameters)
                {
                    // create new sql parameter and assign data table to parameter
                    SqlParameter sqlParam = command.Parameters.AddWithValue(
                        keyValue.Value.Name,
                        typedDataSet.Tables[keyValue.Key]);

                    // set sql db type and sql server user defined table data type name.
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    sqlParam.TypeName = keyValue.Value.ParameterValue.ToString();
                }
            }

            // execute stored procedure and fill result to data set 
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // data set has one or more tables then map that with adapter default table settings
                if (typedDataSet.Tables != null && typedDataSet.Tables.Count > 0)
                {
                    // map first table in data set with adapter table
                    adapter.TableMappings.Add("Table", typedDataSet.Tables[0].TableName);

                    // iterate trough each table in the dataset.
                    for (int tableIndex = 1; tableIndex < typedDataSet.Tables.Count; tableIndex++)
                    {
                        adapter.TableMappings.Add(("Table" + tableIndex), typedDataSet.Tables[tableIndex].TableName);
                    }
                }

                // fill dataset using adapter
                adapter.Fill(outputTypedDataSet);
            }

            return outputTypedDataSet;
        }

        /// <summary>
        ///     Execute specified stored procedure
        /// </summary>
        /// <param name="storedProcName">
        ///     Name of the stored procedure to be executed
        /// </param>
        /// <param name="inputParameters">
        ///     Stored procedure input parameters
        /// </param>   
        /// <returns>
        ///     Returns number of rows affected
        /// </returns>
        /// 

        public List<string> GetDocumentsList(string storedProcName)
        {
            List<string> docs = new List<string>();
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(storedProcName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet ds = new DataSet();
            da.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                docs.Add(ds.Tables[0].Rows[i][0].ToString());
            }

            return docs;
        }

        public string getEmailidinfo(string storedProcName, SqlParameter[] dbparam)
        {
            string resEmailid = null;

            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(storedProcName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;

            if (dbparam != null)
            {
                foreach (SqlParameter dbp in dbparam)
                {

                    command.Parameters.Add(dbp);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataSet ds = new DataSet();
            da.Fill(ds);

            resEmailid = ds.Tables[0].Rows[0][0].ToString();

            return resEmailid;

        }

        public int ExecuteStoredProcedure(string storedProcName, List<DbParameter> inputParameters)
        {
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(storedProcName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;

            // iterate through each input parameter list and create sql parameter object.
            if (inputParameters != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in inputParameters)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.DbType = dbParam.DataType;
                    sqlParam.Size = dbParam.Size;
                    sqlParam.Direction = dbParam.SPParameterDirection;
                    if (sqlParam.Direction != ParameterDirection.Output)
                    {
                        sqlParam.Value = dbParam.ParameterValue;
                    }

                    command.Parameters.Add(sqlParam);
                }
            }

            // execute stored procedure.
            int result = command.ExecuteNonQuery();

            // retrieve value of output parameter from command object 
            // and assign to the dbparameter object.
            foreach (DbParameter outputParameter in inputParameters)
            {
                // checks parameter is input or output.
                if (outputParameter.SPParameterDirection == ParameterDirection.Output ||
                    outputParameter.SPParameterDirection == ParameterDirection.InputOutput)
                {
                    outputParameter.ParameterValue = command.Parameters[outputParameter.Name].Value;
                }
            }

            return result;
        }

        public DataSet GetDataSet(string storedProcName, List<DbParameter> inputParameters)
        {
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(storedProcName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.Transaction = this.transaction;

            // iterate through each input parameter list and create sql parameter object.
            if (inputParameters != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in inputParameters)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.DbType = dbParam.DataType;
                    sqlParam.Size = dbParam.Size;
                    sqlParam.Direction = dbParam.SPParameterDirection;
                    if (sqlParam.Direction != ParameterDirection.Output)
                    {
                        sqlParam.Value = dbParam.ParameterValue;
                    }

                    command.Parameters.Add(sqlParam);
                }
            }

            // execute stored procedure.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);


            DataSet result = new DataSet();
            dataAdapter.Fill(result);

            // retrieve value of output parameter from command object 
            // and assign to the dbparameter object.
            foreach (DbParameter outputParameter in inputParameters)
            {
                // checks parameter is input or output.
                if (outputParameter.SPParameterDirection == ParameterDirection.Output)
                {
                    outputParameter.ParameterValue = command.Parameters[outputParameter.Name].Value;
                }
            }

            return result;
        }

        /// <summary>
        ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the out put parameters
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
        ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the out put parameters
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
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(typedDataSet.StoredProcedureName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;
            command.CommandTimeout = 0;

            // iterate through each input parameter list and create sql parameter object.
            if (typedDataSet.InputParams != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in typedDataSet.InputParams)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.DbType = dbParam.DataType;
                    sqlParam.Size = dbParam.Size;
                    sqlParam.Direction = dbParam.SPParameterDirection;
                    if (sqlParam.Direction != ParameterDirection.Output)
                    {
                        sqlParam.Value = dbParam.ParameterValue;
                    }

                    command.Parameters.Add(sqlParam);
                }
            }

            // execute stored procedure and fill result to data set 
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // data set has one or more tables then map that with adapter default table settings
                if (typedDataSet.Tables != null && typedDataSet.Tables.Count > 0)
                {
                    // map first table in data set with adapter table
                    adapter.TableMappings.Add("Table", typedDataSet.Tables[0].TableName);

                    // iterate trough each table in the dataset.
                    for (int tableIndex = 1; tableIndex < typedDataSet.Tables.Count; tableIndex++)
                    {
                        adapter.TableMappings.Add(("Table" + tableIndex), typedDataSet.Tables[tableIndex].TableName);
                    }
                }

                // fill dataset using adapter
                int result = adapter.Fill(typedDataSet);

                // checks number of records affected by the query
                if (forceOutputParameter || result > 0)
                {
                    if (typedDataSet.InputParams != null)
                    {
                        // retrieve value of output parameter from command object 
                        // and assign to the dbparameter object.
                        foreach (DbParameter outputParameter in typedDataSet.InputParams)
                        {
                            // checks parameter is input or output.
                            if (outputParameter.SPParameterDirection == ParameterDirection.Output
                                || outputParameter.SPParameterDirection == ParameterDirection.InputOutput)
                            {
                                outputParameter.ParameterValue = command.Parameters[outputParameter.Name].Value;
                            }
                        }
                    }
                }
            }

            return typedDataSet;
        }

        #endregion

        #region extendedTypedDataset
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
        public T GetDataSetExtended<T>(T typedDataSet, string procedureName, List<DbParameter> inputParameter) where T : DataSet, IDataSet
        {
            // create sql command object for stored procedure execution
            SqlCommand command = new SqlCommand(procedureName, this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = this.connection;

            // iterate through each input parameter list and create sql parameter object.
            if (inputParameter != null)
            {
                // create input parameter for stored procedure.
                foreach (DbParameter dbParam in inputParameter)
                {
                    SqlParameter sqlParam = new SqlParameter(dbParam.Name, dbParam.DataType);
                    sqlParam.Value = dbParam.ParameterValue;
                    command.Parameters.Add(sqlParam);
                }
            }

            // execute stored procedure and fill result to data set 
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // data set has one or more tables then map that with adapter default table settings
                if (typedDataSet.Tables != null && typedDataSet.Tables.Count > 0)
                {
                    // map first table in data set with adapter table
                    adapter.TableMappings.Add("Table", typedDataSet.Tables[0].TableName);

                    // iterate trough each table in the dataset.
                    for (int tableIndex = 1; tableIndex < typedDataSet.Tables.Count; tableIndex++)
                    {
                        adapter.TableMappings.Add(("Table" + tableIndex), typedDataSet.Tables[tableIndex].TableName);
                    }
                }

                // fill dataset using adapter
                adapter.Fill(typedDataSet);
            }

            return typedDataSet;
        }

        #endregion
    }
}