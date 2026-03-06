using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ShareU4
{
    public class ConnectionLink
    {
        public SqlConnection GetConnection()
        {
            var connStr = ConfigurationManager.ConnectionStrings["ShareUDb"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;
        }
    }
}