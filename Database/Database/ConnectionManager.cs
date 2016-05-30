using System.Data;
using MySql.Data.MySqlClient;

namespace Database
{
    public class ConnectionManager
    {
        private readonly string connectionString;
        /// <summary>
        /// Same as ConnectionManager(0)
        /// </summary>
        public ConnectionManager() : this(0)
        {
        }

        /// <summary>
        /// Loads the properties with index connectionId from the settings.
        /// </summary>
        /// <param name="connectionId">The index of the collections to be used from the settings.</param>
        public ConnectionManager(int connectionId)
        {
            string servername = Properties.Settings.Default.servername[connectionId];
            string database = Properties.Settings.Default.database[connectionId];
            string uid = Properties.Settings.Default.usename[connectionId];
            string pwd = Properties.Settings.Default.password[connectionId];
            connectionString = "Server=" + servername + ";Database=" + database + ";Uid=" + uid + ";Pwd=" + pwd + ";";
        }

        public IDbConnection GetDbConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
