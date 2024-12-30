using CST323Milestone.Models;
using CST323Milestone.Services.DataAccess;
using MySql.Data.MySqlClient;

namespace CST323Milestone.Services.Data
{
    public class JetSkiData
    {
        // Class Level Variables
        // Connection string to the Azure database
        private string ConnectionString = "Server=cst323jetskimilestone.mysql.database.azure.com;Database=cst323jetskis;Uid=Steven;Pwd=Password!;";
        private readonly ILogger<JetSkiData> _logger;

        /// <summary>
        /// ASP.NET Cores built in logger
        /// </summary>
        /// <param name="logger"></param>
        public JetSkiData(ILogger<JetSkiData> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// This method gets all the Jet Ski's in the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<JetSkiModel> GetAllJetSkis()
        {
            // Declare and initialize a list of saved games
            List<JetSkiModel> listOfJetSkis = new List<JetSkiModel>();

            // Query string to query db for all of the saved games based on the userId
            string sqlStatement = "SELECT * FROM jetskis";



            // using statement to ensure objects are disposed of correctly.
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                // Use try catch when opening a db just in case ther is an exception
                try
                {
                    // User the connection object
                    connection.Open();
                    _logger.LogInformation("(Class: JetSkiData, Method: GetAllJetSkis has been called)");


                    //Execute the query and read the results
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // add the jet ski to the list of jet skis
                        listOfJetSkis.Add(new JetSkiModel((int)reader[0], (string)reader[1], (string)reader[2],
                            (string)reader[3], (string)reader[4], (int)reader[5], (int)reader[6]));
                    }
                    _logger.LogInformation("Retrieved all Jet Skis)");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex.Message);

                }
            }
            // Return the the list of saved games for that user.
            return listOfJetSkis;
        }

        /// <summary>
        /// This method deletes a jet ski from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteJetSki(int id)
        {
            // Declare and Initialize 
            int rowsAffected = -1;

            // Delete Query
            string deleteStatement = "DELETE FROM jetskis WHERE Id = @Id";

            _logger.LogInformation("(Class: JetSkiData, Method: DeleteJetSki has been called)");


            //Implement IDisposable - its purpos is to free up resources that were used inside the using statement
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                //Nested using statements allows for proper management of multiple resource, ensuring that eaach resource
                // is disposed of correctly.
                using (MySqlCommand command = new MySqlCommand(deleteStatement, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Rows affected: " + rowsAffected);

                        _logger.LogInformation("Successfully deleted a Jet Ski");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting record: " + ex.Message);
                        _logger.LogError(ex.Message);
                        rowsAffected = 0;
                    }
                }
            }
            return rowsAffected;

        }

        /// <summary>
        /// This method gets a jet ski by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JetSkiModel GetJetSkiById(int id)
        {
            JetSkiModel FoundJetSki = null;

            // Query string
            // Should be the same for MySql
            string sqlStatement = "SELECT * FROM jetSkis WHERE Id = @Id";

            // Use using so all connections get closed when done
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                // Fill in the placeholder for the query string 
                command.Parameters.AddWithValue("@Id", id);

                _logger.LogInformation("(Class: JetSkiData, Method: GetJetSkiById has been called)");

                try
                {
                    connection.Open();

                    // Open up the reader. ExecuteReader reutrns object that can be iterated over to read entire results set.
                    MySqlDataReader reader = command.ExecuteReader();

                    //Then read the results of the query (Only have one result)
                    //while (reader.Read())
                    if (reader.Read())
                    {
                        //Populate the results
                        FoundJetSki = new JetSkiModel((int)reader[0], (string)reader[1], (string)reader[2],
                            (string)reader[3], (string)reader[4], (int)reader[5], (int)reader[6]);

                        _logger.LogInformation("Found Jet Ski by Id");

                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                    _logger.LogError(exp.Message);

                };
            }
            // FoundProduct might be null
            return FoundJetSki;

        }

        /// <summary>
        /// This method updates a jet ski in the database
        /// </summary>
        /// <param name="jetSki"></param>
        /// <returns></returns>
        public int Update(JetSkiModel jetSki)
        {
            // Declare and Initialize 
            int newIdNumber = -1;

            _logger.LogInformation("(Class: JetSkiData, Method: Update has been called)");


            // Create the Update Query string
            string sqlStatement = "UPDATE jetskis SET Image = @Image, Make = @Make, Model = @Model, Color = @Color, Year = @Year, Price = @Price WHERE Id = @Id";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                // Create an object so we can pass commands to sql
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", jetSki.Id);
                command.Parameters.AddWithValue("@Image", jetSki.Image);
                command.Parameters.AddWithValue("@Make", jetSki.Make);
                command.Parameters.AddWithValue("@Model", jetSki.Model);
                command.Parameters.AddWithValue("@Color", jetSki.Color);
                command.Parameters.AddWithValue("@Year", jetSki.Year);
                command.Parameters.AddWithValue("@Price", jetSki.Price);



                try
                {
                    connection.Open();

                    // ExecuteScalar a single value
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());

                    _logger.LogInformation("Updated a Jet Ski sucessfully");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex.Message);

                };
            }
            //return the numbr of rows updated
            return newIdNumber;
        }

        /// <summary>
        /// This method adds a jet ski to the database
        /// </summary>
        /// <param name="newJetSki"></param>
        /// <returns></returns>
        public bool AddJetSki(JetSkiModel newJetSki)
        {
            // Declare and initialize our flag as false
            bool isSuccessful = false;

            _logger.LogInformation("(Class: JetSkiData, Method: AddJetSki has been called)");


            // Query string to query db for inserting a saved game
            string sqlStatement = "INSERT INTO jetskis (Id, Image, Make, Model, Color, Year, Price) VALUES (NULL, @Image, @Make, @Model, @Color, @Year, @Price)";
            // using statement to ensure objects are disposed of correctly.
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);

                command.Parameters.Add("@Id", MySqlDbType.Int32, 11).Value = newJetSki.Id;
                command.Parameters.Add("@Image", MySqlDbType.VarChar, 1000).Value = newJetSki.Image;
                command.Parameters.Add("@Make", MySqlDbType.VarChar, 50).Value = newJetSki.Make;
                command.Parameters.Add("@Model", MySqlDbType.VarChar, 50).Value = newJetSki.Model;
                command.Parameters.Add("@Color", MySqlDbType.VarChar, 30).Value = newJetSki.Color;
                command.Parameters.Add("@Year", MySqlDbType.Int32, 11).Value = newJetSki.Year;
                command.Parameters.Add("@Price", MySqlDbType.Int32, 11).Value = newJetSki.Price;

                // Use try catch when opening a db just in case ther is an exception
                try
                {
                    // User the connection object
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        isSuccessful = true;
                        Console.WriteLine("RowsAffected: {0}", rowsAffected);
                        _logger.LogInformation("Created a new Jet Ski successfully");

                    }
                    else
                    {
                        Console.WriteLine("No rows affected. Check the data or table structure.");
                        _logger.LogError("Something went wrong when creating a new Jet Ski");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex.Message);

                }
            }
            // Return the result
            return isSuccessful;
        }

    }
}
