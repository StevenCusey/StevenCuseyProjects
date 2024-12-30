using CST323Milestone.Controllers;
using CST323Milestone.Models;
using CST323Milestone.Services.DataAccess;
using NLog;

namespace CST323Milestone.Services.Business
{
    public class SecurityService
    {
        // Class Level Variables
        private readonly ILogger<SecurityService> _logger;
        private readonly SecurityDAO _securityDAO;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected securityDAO
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="securityDAO"></param>
        public SecurityService(ILogger<SecurityService> logger, SecurityDAO securityDAO)
        {
            _logger = logger;
            _securityDAO = securityDAO;
        }




        /// <summary>
        /// Calls the data in SecurityDAO class to see if the user logged in properly
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool IsValid(UsersLoginModel users)
        {
            _logger.LogInformation("(Class: SecurityService, Method: IsValid has been called)");

            bool result = _securityDAO.FindByUserData(users);
            return result;
        }

        /// <summary>
        /// Checks with the Security Data Access Object to try to register a users
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool Registerusers(UsersRegisterModel users)
        {

            _logger.LogInformation("(Class: SecurityService, Method: Registerusers has been called)");

            bool result = _securityDAO.AddByUserData(users);
            return result;
        }






    }
}
