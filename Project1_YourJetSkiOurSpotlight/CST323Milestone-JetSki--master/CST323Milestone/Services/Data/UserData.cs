using CST323Milestone.Models;
using CST323Milestone.Services.DataAccess;
using MySql.Data.MySqlClient;

namespace CST323Milestone.Services.Data
{
    public class UserData
    {
        // Class Level Variables
        // Connection string to the Azure database
        private string connectionString = "Server=cst323jetskimilestone.mysql.database.azure.com;Database=cst323jetskis;Uid=Steven;Pwd=Password!;";
        private readonly ILogger<UserData> _logger;

        /// <summary>
        /// ASP.NET Cores built in logger
        /// </summary>
        /// <param name="logger"></param>
        public UserData(ILogger<UserData> logger)
        {
            _logger = logger;
        }




        /// <summary>
        /// Retrieves user from database after login
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool FindByUserData(UsersLoginModel users)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM users WHERE email = @email AND password = @password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@email", users.Email);
                command.Parameters.AddWithValue("@password", users.Password);

                try
                {
                    connection.Open();

                    _logger.LogInformation("(Class: UserData, Method: FindByUserData has been called)");


                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                        reader.Read();
                        users.Id = reader.GetInt32(0);
                        _logger.LogInformation("User's login credentials have been found and is valid");

                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex.Message);

                }
                return success;
            }
        }

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddByUserData(UsersRegisterModel users)
        {
            bool success = false;
            string sqlStatementCheck = "SELECT * FROM users WHERE email = @email";
            string sqlStatementInsert = "INSERT INTO users (FirstName, LastName, Email, Password) VALUES (@first, @last, @email,  @password)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlStatementCheck, connection);
                    command.Parameters.AddWithValue("@email", users.Email);

                    _logger.LogInformation("(Class: UserData, Method: AddByUserData has been called)");



                    MySqlDataReader reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        command = new MySqlCommand(sqlStatementInsert, connection);
                        command.Parameters.AddWithValue("@first", users.FirstName);
                        command.Parameters.AddWithValue("@last", users.LastName);
                        command.Parameters.AddWithValue("@email", users.Email);
                        command.Parameters.AddWithValue("@password", users.Password);
                        success = command.ExecuteNonQuery() > 0;
                        _logger.LogInformation("Creation of new user is successful");
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.LogError(ex.Message);
                }
            }

            return success;
        }

    }
}
