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
        private static string connString = $"Data Source=nept;User ID=nept_pdo;Password=nept_pdo; Persist Security Info=true";

        public static IDbConnection GetConnection()
        {
            var conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection(IDbConnection conn)
        {
            if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
            {
                conn.Close();
            }
        }
    }
}
