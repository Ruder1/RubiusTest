using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Infrastructure
{
    public class Connection
    {
        private static string connString = "Data Source=(DESCRIPTION=" +
            "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=host id)" +
            "(PORT=specified port number)))(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=service name)));" +
            "User Id = user Id; Password = your password; ";

        public static IDbConnection GetConnection()
        {
            var conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
