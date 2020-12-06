using Oracle.ManagedDataAccess.Client;
using System.Data;

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
    }
}
