﻿using Cupcakes.Models;
using Microsoft.Data.Sqlite;

namespace Cupcakes.Data
{
    //
    // This is a utility class that will be used to connect to the database and execute CRUD operations.
    //
    public static class DbContext
    {
        // Get a cupcake by its id
        public static Cupcake GetCupcakeById(int cupcakeId) 
        {
            Cupcake cupcake = new Cupcake();
            // Create connection to database
            SqliteConnection connection = new SqliteConnection("Data Source=Data/cupcakes.db");

            // Open the connection
            connection.Open();

            // Run SQL to get a cupcake by its id
            string sql = "SELECT CupcakeId, Name, ImageFileName, Description, Price FROM Cupcake WHERE CupcakeId = @CupcakeId";

            // Create a "command" (sql to execute in database) to execute SQL
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Basically do a find and replace in the sql string
            cmd.Parameters.AddWithValue("@CupcakeId", cupcakeId);

            // Execute the command (use a Data Reader so we can read() the rows returned by the command)
            SqliteDataReader reader = cmd.ExecuteReader();

            // Read through the result (if any)
            reader.Read();
            cupcake.CupcakeId = reader.GetInt32(0);
            cupcake.Name = reader.GetString(1);
            cupcake.ImageFileName = reader.GetString(2);
            cupcake.Description = reader.GetString(3);
            cupcake.Price = reader.GetDecimal(4);

            // Close the connection
            connection.Close();

            return cupcake;

        }
        // Get all cupcakes from the database
        public static List<Cupcake> GetAllCupcakes()
        {
            List<Cupcake> cupcakes = new List<Cupcake>();
            
            // Query the database to get all cupcakes

            // Create connection to database
            SqliteConnection connection = new SqliteConnection("Data Source=Data/cupcakes.db");
            
            // Open the connection
            connection.Open();

            // Create Sql command to get all the cupcakes
            string sql = "SELECT CupcakeId, Name, ImageFileName, Description, Price FROM Cupcake ORDER BY Name";

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

        // Add a new cupcake object to the database
        public static void AddNewCupcake(Cupcake cupcake)
        {
            // Create connection to database
            SqliteConnection connection = new SqliteConnection("Data Source=Data/cupcakes.db");
            
            // Open the connection
            connection.Open();

            // Create Sql command to add new cupcakes
            // Use parameters to prevent SQL injection attacks
            string sql = "INSERT INTO Cupcake (Name, ImageFileName, Description, Price) VALUES (@Name, @ImageFileName, @Description, @Price)";

            // Create command object to execute the query
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@Name", cupcake.Name);
            cmd.Parameters.AddWithValue("@ImageFileName", cupcake.ImageFileName);
            cmd.Parameters.AddWithValue("@Description", cupcake.Description);
            cmd.Parameters.AddWithValue("@Price", cupcake.Price);

            // Execute the query
            cmd.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }   
        
        // Remove a cupcake from the database
        public static void RemoveCupcake(int cupcakeId)
        {
            // Create connection to database
            SqliteConnection connection = new SqliteConnection("Data Source=Data/cupcakes.db");
            
            // Open the connection
            connection.Open();

            // Create Sql command to remove cupcake
            // Use parameters to prevent SQL injection attacks
            string sql = "DELETE FROM Cupcake WHERE CupcakeId = @CupcakeId";

            // Create command object to execute the query
            SqliteCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@CupcakeId", cupcakeId);

            // Execute the query
            cmd.ExecuteNonQuery();

            // Close the connection
            connection.Close();
        }
    }
}
