using PopulationReportingSystem.Database;
using MySql.Data.MySqlClient;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Connection string for 'world' database (add password if needed)
        string connectionString = "server=localhost;user=root;database=world;port=3306;password=";

        // Create a DatabaseConnection object
        DatabaseConnection db = new DatabaseConnection(connectionString);

        // Open the connection
        db.Open();

        try
        {
            // SQL Query: List all countries by population in descending order
            string query = @"SELECT Code, Name, Continent, Region, Population 
                             FROM country 
                             ORDER BY Population DESC";

            // Execute the query
            using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                Console.WriteLine("\n List of Countries by Population:");
                Console.WriteLine("-----------------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"Code: {reader["Code"]}, Name: {reader["Name"]}, " +
                                      $"Continent: {reader["Continent"]}, Region: {reader["Region"]}, " +
                                      $"Population: {reader["Population"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Query Error: {ex.Message}");
        }
        finally
        {
            // Close the connection
            db.Close();
        }
    }
}
