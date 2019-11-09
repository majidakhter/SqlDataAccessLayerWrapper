using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using AromaCareGlow.Framework.DataAccess.Models.Mapping;

namespace AromaCareGlow.Framework.Server.Facade
{


    ///     Created By :   Majid Akhter                 Modified By:
    ///     Created Date:   19/06/2019                  Modified Date:

    public interface IShipment
    {
        #region shipment

        //get all the shipment done on a particular month for a customer

        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="dateType"></param>
        /// <returns>dataset</returns>

        T GetShipmentBol<T>(T typedDataSet) where T : DataSet, IDataSet;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typedDataSet"></param>
        /// <returns></returns>
        T GetallCarriersQuote<T>(T typedDataSet) where T : DataSet, IDataSet;

        /// <summary>
        /// To get all the shipments of a customer and to show in shipper home
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typedDataSet"></param>
        /// <returns></returns>
        T GetShipmentDetails<T>(T typedDataSet) where T : DataSet, IDataSet;
    }
    #endregion
}