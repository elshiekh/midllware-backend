using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ePharmacy_Out.Extenstion
{
    public static class QueryExtenstion
    {
        public static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            command.BindByName = true;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        public static List<string> ColumnList(this IDataReader dataReader)
        {
            var columns = new List<string>();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                columns.Add(dataReader.GetName(i));
            }
            return columns;
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                try
                {
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return list;
        }

        public static List<T> SetCaching<T>(IMemoryCache _mCache, string cacheKey, List<T> response)
        {
            List<T> value;
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(10),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(10)
            };
            _mCache.Set(cacheKey, response, cacheExpiryOptions);
            _mCache.TryGetValue(cacheKey, out value);

            return value;
        }

        public static string EncodeStringToBase64(string stringToEncode)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToEncode));
        }
        public static string XmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return jsonText;
        }

        /// <summary>
        /// Maps a SqlDataReader record to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <param name="newObject"></param>
        /// 

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static List<T> ToDelimitedList<T>(this string value, string delimiter, Func<string, T> converter)
        {
            if (value == null)
            {
                return new List<T>();
            }

            var output = value.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            return output.Select(converter).ToList();
        }
    }
}
