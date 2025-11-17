using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalsSystem.Database
{
    public class dbConnection
    {
        private static readonly Lazy<dbConnection> instance = new Lazy<dbConnection>(() => new dbConnection());
        private MySqlConnection connection;

        private dbConnection()
        {
            string connectionString = "server=localhost;database=CarDB;user=root;password=;";
            connection = new MySqlConnection(connectionString);
        }

        public static dbConnection Instance => instance.Value;

        public MySqlConnection Connection
        {
            get
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return connection;
            }
        }
    }
}
