using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Vida.Extenstion
{
    public static class QueryExtenstion
    {
        public static OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            OracleCommand command = new OracleCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (OracleParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        public static string ToXml(this object objectToSerialize)
        {
            var mem = new MemoryStream();
            var ser = new XmlSerializer(objectToSerialize.GetType());
            ser.Serialize(mem, objectToSerialize);
            var utf8 = new UTF8Encoding();
            return utf8.GetString(mem.GetBuffer(), 0, (int)mem.Length);
        }
    }
}
