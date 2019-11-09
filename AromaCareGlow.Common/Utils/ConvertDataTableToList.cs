using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace AromaCareGlow.Common.Utils
{
    public class ConvertDataTableToList
    {
        /// <summary>
        /// Convert a DataTable to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// 
        public static List<T> ConvertToList<T>(DataTable dt) where T : class, new()
        {
            if (dt == null || dt.Rows.Count == 0) return null;
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T obj = ConvertDataRowToEntity<T>(row);
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Convert a single DataRow into an object of type T.
        /// </summary>
        public static T ConvertDataRowToEntity<T>(DataRow row) where T : class, new()
        {
            Type objType = typeof(T);
            T obj = Activator.CreateInstance<T>(); //hence the new() contsraint
            //Debug.WriteLine(objType.Name + " = new " + objType.Name + "();");
            foreach (DataColumn column in row.Table.Columns)
            {
                //may error if no match
                PropertyInfo property =
                    objType.GetProperty(column.ColumnName,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property == null || !property.CanWrite)
                {
                    //Debug.WriteLine("//Property " + column.ColumnName + " not in object");
                    continue; //or throw
                }
                object value = row[column.ColumnName];
                if (value == DBNull.Value) value = null;
                property.SetValue(obj, value, null);
                //Debug.WriteLine("obj." + property.Name + " = row[\"" + column.ColumnName + "\"];");
            }
            return obj;
        }
    }
}
