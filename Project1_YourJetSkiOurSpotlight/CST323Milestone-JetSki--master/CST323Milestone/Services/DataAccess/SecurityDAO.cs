using MySql.Data.MySqlClient;
using CST323Milestone.Models;
using CST323Milestone.Services.Data;
using CST323Milestone.Services.Business;

namespace CST323Milestone.Services.DataAccess
{
    public class SecurityDAO
    {
        // Class Level Variables
        private readonly ILogger<SecurityDAO> _logger;
        private readonly UserData _userData;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected userData
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="userData"></param>
        public SecurityDAO(ILogger<SecurityDAO> logger, UserData userData)
        {
            _logger = logger;
            _userData = userData;
        }

        /// <summary>
        /// Finds a user
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool FindByUserData(UsersLoginModel users)
        {
            _logger.LogInformation("(Class: SecurityDAO, Method: FindByUserData has been called)");

            return _userData.FindByUserData(users);
        }

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddByUserData(UsersRegisterModel users)
        {
            _logger.LogInformation("(Class: SecurityDAO, Method: AddByUserData has been called)");

            return _userData.AddByUserData(users);
        }


    }
}
