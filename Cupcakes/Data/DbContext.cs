using Cupcakes.Models;
using Microsoft.Data.Sqlite;

namespace Cupcakes.Data
{
    //
    // This is a utility class that will be used to connect to the database and execute CRUD operations.
    //
    public static class DbContext
    {
        public static List<Cupcake> GetAllCupcakes()
        {
            List<Cupcake> cupcakes = new List<Cupcake>();
            
            // Query the database to get all cupcakes

            // Create connection to database
            SqliteConnection connection = new SqliteConnection("Data Source=Data/cupcakes.db");
            
            // Open the connection
            connection.Open();

            // Create Sql command to get all the cupcakes
            string sql = "SELECT CupcakeId, Name, ImageFileName, Description, Price FROM Cupcake";

            // Create command object to execute the query
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Execute the query (use a Data Reader so we can read() the rows)
            SqliteDataReader reader = cmd.ExecuteReader();

            // Read each row
            while (reader.Read())
            {
                // Create a new cupcake object
                Cupcake cupcake = new Cupcake();

                // Set the properties on the cupcake object
                cupcake.CupcakeId = reader.GetInt32(0);
                cupcake.Name = reader.GetString(1);
                cupcake.ImageFileName = reader.GetString(2);
                cupcake.Description = reader.GetString(3);
                cupcake.Price = reader.GetDecimal(4);

                // Add the cupcake object to the list
                cupcakes.Add(cupcake);
            }
            // Close the connection
            connection.Close();

            return cupcakes;
        }   
    }
}
