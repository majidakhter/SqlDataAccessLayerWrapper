//------------------------------------------------------------------------------ 
// <copyright file="ICustom.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using AromaCareGlow.Framework.DataAccess.Models.Mapping;
using System;

namespace AromaCareGlow.Framework.Server.Facade
{
    /// <summary>
    ///     Interface for CRUD operations (Create, Retrieve, Update and Delete) using typed dataset. 
    ///     and other custom operations.All the methods defined in this interface are generic methods 
    ///     therefore we can use these methods for CRUD operations of any typed dataset 
    ///     object which implements IDataSet interface.
    /// 
    ///     Created By :    Majid Akhter                       Modified By: 
    ///     Created Date:   06/10/2019                 Modified Date:
    ///     ----------------------------------------------------------
    ///     New method add for insert operation using table valued parameters and 
    ///     to fetch the new table values in the type dataset
    ///     ----------------------------------------------------------
    /// </summary>
    public interface ICustom
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
        T GetDataSet<T>(T typedDataSet) where T : DataSet, IDataSet;

        /// <summary>
        ///     Save data in the data set in persistent storage, it use table valued 
        ///     data type functionality SQL Server 2008.
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet and ISQLTableType interface.
        /// </typeparam>
        /// <param name="typedDataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///     A typed dataset instance, filled with query execution result.
        /// </returns>
        int InsertSQLTableType<T>(T typedDataSet) where T : DataSet, IDataSet, ISQLTableType;

        /// <summary>
        ///     Save data in the data set in persistent storage and 
        ///     to fetch the new table values in the type dataset, 
        ///     it use table valued data type functionality SQL Server 2008.
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet and ISQLTableType interface.
        /// </typeparam>
        /// <param name="typedDataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///     Returns number of rows affected
        /// </returns>
        T InsertSelectSQLTableType<T>(T typedDataSet, T outputTypedDataSet) where T : DataSet, IDataSet, ISQLTableType;

        /// <summary>
        ///     Execute specified stored procedure
        /// </summary>
        /// <param name="storedProcName">
        ///     Name of the stored procedure to be executed
        /// </param>
        /// <param name="inputParameters">
        ///     Stored procedure input parameters
        /// </param>
        /// <param name="serverType">
        ///     Sql server type to be connected.
        /// </param>
        /// <returns>
        ///     Returns number of rows affected
        /// </returns>
        int ExecuteStoredProcedure(string storedProcName, List<DbParameter> inputParameters, ServerTypes serverType);

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
        T GetDataSetWithParameters<T>(T typedDataSet) where T : DataSet, IDataSet;

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
        T GetDataSetWithParameters<T>(T typedDataSet, Boolean forceOutputParameter) where T : DataSet, IDataSet;



    }
}