using FastMember;
using HMGOnBaseOut.DTO;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
//using Devart.Data.Oracle;

namespace HMGOnBaseOut.Extenstion
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
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                        
                
                }
             list.Add(obj);
            }
            return list;
        }

        public static List<T> CustomDataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            int count = 0;
            try
            {
                while (dr.Read())
                {
                    count = count + 1;
                    obj = Activator.CreateInstance<T>();
                    var xmlString = "";
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            if (prop.Name != "EMPLOYEE_DOCUMENTS")
                            {
                                prop.SetValue(obj, dr[prop.Name], null);
                            }
                            else
                            {
                                xmlString = dr[prop.Name].ToString();
                                var myObject = DeserializeXMLObject(xmlString);
                                prop.SetValue(obj, myObject, null);
                                xmlString = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        
                    }
                    list.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
            var countNumber = count;

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

        public static T ConvertToObject<T>(this IDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                }
            }

            return t;
        }

        public static List<ROW> DeserializeXMLObject(string xml)
        {
            try
            {
                XDocument doc = new XDocument();
                //Check for empty string.
                if (!string.IsNullOrEmpty(xml))
                {
                    doc = XDocument.Parse(xml);
                }
                List<ROW> ROWSET = new List<ROW>();
                //Check if xml has any elements 
                if (!string.IsNullOrEmpty(xml) && doc.Root.Elements().Any())
                {
                    ROWSET = doc.Descendants("ROW").Select(d =>
                    new ROW
                    {
                        DOCUMENT_TYPE = d.Element("DOCUMENT_TYPE").Value,
                        REQUIRED_FLAG = d.Element("REQUIRED_FLAG").Value
                    }).ToList();
                }

                return ROWSET;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         

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
    }
}
