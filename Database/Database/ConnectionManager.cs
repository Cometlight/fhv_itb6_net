using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Database
{
    public class ConnectionManager
    {
        private static readonly string connectionString;
        static ConnectionManager()
        {
            //            string servername = Database.Properties.Settings.Default.servername;
            //            string database = Database.Properties.Settings.Default.database;
            //            string uid = Database.Properties.Settings.Default.usename;
            //            string pwd = Database.Properties.Settings.Default.password;
            string servername = "localhost";
            string database = "net_db_local";
            string uid = "fhv";
            string pwd = "datenmanagement";
            connectionString = "Server=" + servername + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd + ";";
        }

        public static IDbConnection GetDbConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
