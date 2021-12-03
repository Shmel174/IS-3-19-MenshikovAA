using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDB
{
    public static class ConnDB_Lib
    {
        public static MySqlConnection connDB_lib()
        {
            string host = "caseum.ru";
            string port = "33333";
            string user = "test_user";
            string db = "db_test";
            string password = "test_pass";
            string connStr = $"server={host};port={port};user={user};database={db};password={password};";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    }
}
