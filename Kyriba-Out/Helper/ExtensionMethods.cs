using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Kyriba_Out.DTO;
using System.Text;

namespace Kyriba_Out.Helper
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }

        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                var stringwriter = new StringWriter();
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch
            {
                throw;
            }
        }

        public static string CreateXML(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
                                                      // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject, ns);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static IEnumerable<Dictionary<string, object>> ConvertToDictionary(IDataReader reader)
        {
            var columns = new List<string>();
            var rows = new List<Dictionary<string, object>>();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }

            while (reader.Read())
            {
                rows.Add(columns.ToDictionary(column => column, column => reader[column]));
            }

            return rows;
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
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        //public static byte[] DecodeUrlBase64(string s)
        //{
        //    if (String.IsNullOrWhiteSpace(s)) return null;
        //    try
        //    {
        //        string working = s.Replace('-', '+').Replace('_', '/'); ;
        //        while (working.Length % 4 != 0)
        //        {
        //            working += '=';
        //        }
        //        return Convert.FromBase64String(working);
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public static DecodeBase64Response DecodeUrlBase64(string s)
        {
            DecodeBase64Response result = new DecodeBase64Response();
            try
            {
                //s = s.Replace('-', '+').Replace('_', '/').PadRight(4 * ((s.Length + 3) / 4), '=');
                result.FileInBase64 = Convert.FromBase64String(s);
                result.Staus = true;
                return result;
            }
            catch (Exception ex)
            {
                result.FileInBase64 = null;
                result.Staus = false;
                result.Message = ex.Message.ToString();
                return result;
            }
        }

        public class DecodeBase64Response
        {
            public byte[] FileInBase64 { get; set; }
            public string Message { get; set; }
            public bool Staus { get; set; }
        }
    }
}
