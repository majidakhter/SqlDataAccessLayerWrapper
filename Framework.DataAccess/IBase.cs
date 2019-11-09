//------------------------------------------------------------------------------ 
// <copyright file="IBase.cs" company="AromaCareGlow LLP">
//     Copyright (c) AromaCareGlow LLP.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

using System.Collections.Generic;

using AromaCareGlow.Framework.DataAccess.Models;

namespace AromaCareGlow.Framework.Server.Facade
{
    /// <summary>
    ///     Base interface for CRUD operations (Create, Retrieve, Update and Delete). 
    ///     CRUD operation can be done using stored procedure or direct sql statements.
    ///     All the methods defined in this interface are generic methods therefore we can 
    ///     use these methods for CRUD operations of any class which implements IModel interface.
    /// 
    ///     Created By :    Majid Akhter                       Modified By:
    ///     Created Date:   10/23/2019                Modified Date:
    /// </summary>
    public interface IBase
    {
        #region CRUD Methods

        #region SQL Methods

        /// <summary>
        ///     Save the data in a persistant storage. 
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
        bool Save<T>(T dtoModel) where T : IModel;

        /// <summary>
        ///     Retrieve an entity from the persistant storage using the primary key.
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
        T GetModel<T>(int primaryKey) where T : IModel, new();

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
        List<T> GetModels<T>(string[] fieldNames, string[] fieldValues) where T : IModel, new();

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
        bool Delete<T>(int primaryKey) where T : IModel, new();

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
        bool SaveProcedure<T>(T dtoModel) where T : IModel;

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
        bool InsertTableValuedProcedure<T>(List<T> modelCollection) where T : IModel, new();

        /// <summary>
        ///     Retrieve an entity from the persistant storage using the primary key.
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
        T GetModelProcedure<T>(int primaryKey) where T : IModel, new();

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
        T GetModelProcedure<T>(T model) where T : IModel, new();

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
        List<T> GetModelsProcedure<T>(T model) where T : IModel, new();

        /// <summary>
        ///     Delete the entry from persistant storage using stored procedure.
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
        bool DeleteProcedure<T>(int primaryKey) where T : IModel, new();

        #endregion

        #endregion
    }
}