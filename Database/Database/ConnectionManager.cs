using System.Data;
using MySql.Data.MySqlClient;

namespace Database
{
    /// <summary>
    /// The ConnectionManager is used for creating database connections. It relies on
    /// the filled out settings of this project.
    /// The advantage of having everything centralized in this class is that it's easy
    /// to change for example the IDbConnection type from MySqlConnection to another one.
    /// </summary>
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
