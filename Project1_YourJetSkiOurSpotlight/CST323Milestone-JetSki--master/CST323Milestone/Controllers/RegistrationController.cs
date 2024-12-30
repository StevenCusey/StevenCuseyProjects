using CST323Milestone.Models;
using CST323Milestone.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace CST323Milestone.Controllers
{
    public class RegistrationController : Controller
    {
        // Class Level Variables
        private readonly ILogger<RegistrationController> _logger;
        private readonly SecurityService _securityService;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected security service
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="securityService"></param>
        public RegistrationController(ILogger<RegistrationController> logger, SecurityService securityService)
        {
            _logger = logger;
            _securityService = securityService;

        }


        /// <summary>
        /// Display the registration page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method handles registering a new user
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public IActionResult ProcessRegistration(UsersRegisterModel users)
        {
            // If the user has entered correct user registration credentials
            // Add the new user
            if (_securityService.Registerusers(users))
            {
                _logger.LogInformation("New user has been created");

                // Display registration success
                return View("RegistrationSuccess", users);
            }
            // If the user has entered incorrect user registration credentials
            else
            {
                _logger.LogInformation("Creation of new user has failed");

                // Shows if a user was not created
                return View("RegistrationFailure", users);
            }
        }
    }
}
