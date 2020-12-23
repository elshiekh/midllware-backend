using FastMember;
using HMGOnBaseOut.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
                foreach (System.Reflection.PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.Name != "REQUIRED_DOCUMENTS")
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Maps a SqlDataReader record to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <param name="newObject"></param>
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
                }).ToList();
            }
            return ROWSET;

        }

        public static bool HasColumn(IDataReader Reader, string ColumnName)
        {
            foreach (DataRow row in Reader.GetSchemaTable().Rows)
            {
                if (row["ColumnName"].ToString() == ColumnName)
                    return true;
            } //Still here? Column not found. 
            return false;
        }
    }
}
