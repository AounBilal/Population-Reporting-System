using System;
using MySql.Data.MySqlClient;

namespace PopulationReportingSystem.Database
{
    public class DatabaseConnection
    {
        private MySqlConnection connection;

        public DatabaseConnection(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            try
            {
                connection.Open();
                Console.WriteLine(" Database Connected Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Connection Error: {ex.Message}");
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
