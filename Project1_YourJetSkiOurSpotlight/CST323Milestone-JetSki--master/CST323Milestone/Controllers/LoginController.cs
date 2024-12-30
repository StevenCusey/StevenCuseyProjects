using CST323Milestone.Models;
using CST323Milestone.Services.Business;
using Microsoft.AspNetCore.Mvc;

namespace CST323Milestone.Controllers
{
    public class LoginController : Controller
    {
        // Class Level Variables
        private readonly ILogger<LoginController> _logger;
        private readonly SecurityService _securityService;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected security service
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="securityService"></param>
        public LoginController(ILogger<LoginController> logger, SecurityService securityService)
        {
            _logger = logger;
            _securityService = securityService;

        }


        /// <summary>
        /// The display the login page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _logger.LogInformation("Class: LoginController,  Method: Index has been called)");
            return View();
        }

        /// <summary>
        /// This method handle logging in the user. 
        /// Verifies if the user is valid or not.
        /// </summary>
        /// <param name="user">The user's login credentials</param>
        /// <returns></returns>
		public IActionResult ProcessLogin(UsersLoginModel user)
        {
            _logger.LogInformation("(Class: LoginController, Method: ProcessLogin has been called)");

            // If the user is valid
            if (_securityService.IsValid(user))
            {
                _logger.LogInformation("User Has logged in Successfully");

                // logs in a user
                return RedirectToAction("Index", "JetSkis");

			}
            // If the user is not valid
			else
            {
                _logger.LogInformation("User Entered the wrong credentials to login");

                // shows if login failed
                return View("_LoginFailure", user);
            }
        }
    }
}