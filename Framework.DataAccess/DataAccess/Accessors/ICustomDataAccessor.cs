//------------------------------------------------------------------------------ 
// <copyright file="ICustomDataAccessor.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AromaCareGlow.Framework.DataAccess.Factory.Accessors;
using AromaCareGlow.Framework.DataAccess.Models.Mapping;
using System;

namespace AromaCareGlow.Framework.Server.Facade.DataAccess.Accessors
{
    /// <summary>
    ///		This is an interface for all custom data operations related to carrier rate main. 
    ///		All custom data access methods related to carrier rate main are defined here.
    ///		
    ///     Created By: Majid Akhter                   Created Date:06/10/2019
    ///     Modified By: Majid Akhter                  Modified Date: 07/15/2019
    ///     Comments: New method add for insert operation using table valued parameters.
    ///     Modified By: Litty Thomas                Modified Date: 07/22/2009
    ///     Comments:New method add for insert operation using table valued parameters and 
    ///     to fetch the new table values in the type dataset
    /// </summary>
    public interface ICustomDataAccessor : ICustomAccessor
    {
        #region Methods

        /// <summary>
        ///     Generic data retrieval method for datasets, It fill result to typed dataset
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet interface.
        /// </typeparam>
        /// <param name="dataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///     A typed dataset instance, filled with query execution result.
        /// </returns>
        T GetDataSet<T>(T dataSet) where T : DataSet, IDataSet;

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
        ///     Returns number of rows affected.
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
        /// <returns>
        ///     Returns the resultant row
        /// </returns>
        /// 
        string getEmailidinfo(string storedProcName, SqlParameter[] dbparam);

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
        ///     Returns number of rows affectethe resultset
        /// </returns>
        List<string> GetDocumentsList(string storedProcName);

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

        int ExecuteStoredProcedure(string storedProcName, List<DbParameter> inputParameters);

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

        DataSet GetDataSet(string storedProcName, List<DbParameter> inputParameters);

        /// <summary>
        ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the out put parameters
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet interface.
        /// </typeparam>
        /// <param name="dataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///     A typed dataset instance, filled with query execution result.
        /// </returns>
        T GetDataSetWithParameters<T>(T dataSet) where T : DataSet, IDataSet;

        /// <summary>
        ///     Generic data retrieval method for datasets, It fill result to typed dataset and fill the out put parameters
        /// </summary>
        /// <typeparam name="T">
        ///     Typed dataset that should implement IDataSet interface.
        /// </typeparam>
        /// <param name="dataSet">
        ///     Typed dataset instance, stored procedure name property 
        ///     of this instance should have valid data.
        /// </param>
        /// <returns>
        ///     A typed dataset instance, filled with query execution result.
        /// </returns>
        T GetDataSetWithParameters<T>(T dataSet, Boolean forceOutputParameter) where T : DataSet, IDataSet;

        #endregion

        #region ExtendedTypeDataSet
        T GetDataSetExtended<T>(T typedDataSet, string procedureName, List<DbParameter> inputParameter) where T : DataSet, IDataSet;
        #endregion
    }
}