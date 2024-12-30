using CST323Milestone.Services.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CST323Milestone.Models;
using NuGet.Protocol.Core.Types;


namespace CST323Milestone.Controllers
{
    public class JetSkisController : Controller
	{
        // Class Level Variables
        private readonly ILogger<JetSkisController> _logger;
        private readonly JetSkiService _jetSkiService;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected JetSkiservice
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jetSkiService"></param>
        public JetSkisController(ILogger<JetSkisController> logger, JetSkiService jetSkiService)
        {
            _logger = logger;
            _jetSkiService = jetSkiService;

        }




        /// <summary>
        /// Jet Skis Page
        /// </summary>
        /// <returns></returns>
		public ActionResult Index()
		{
            // List of Jet Skis
			List<JetSkiModel> jetSkis = new List<JetSkiModel>();

            // Retrieve all Jet Skis to display
			jetSkis = _jetSkiService.getAllJetSkis();
            _logger.LogInformation("(Class: JetSkisController, Method: Index has been called)");

            // Displays a list of jetskis
            return View(jetSkis);
		}

        /// <summary>
        /// This method handles deleting a Jet Ski 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteJetSki(int id)
        {
            // This method deletes a jetski the user has specified
			int rowsAffected = _jetSkiService.DeleteJetSki(id);
            _logger.LogInformation("(Class: JetSkisController, Method: DeleteJetSki has been called)");

            // Display the list of Jet Skis after one has been deleted
            return View("Index", _jetSkiService.getAllJetSkis());
        }

        /// <summary>
        /// This method redirects the user to the edit jet ski form page. 
        /// This allows the user to edit an existing jet ski
        /// </summary>
        /// <param name="id">The id of the jet ski the user wants to edit</param>
        /// <returns></returns>
        public ActionResult ShowEditForm(int id)
        {
            _logger.LogInformation("(Class: JetSkisController, Method: ShowEditForm has been called)");

            return View(_jetSkiService.GetJetSkiById(id));
        }

        /// <summary>
        /// This method processes the edit changes that the user has made
        /// </summary>
        /// <param name="jetSki"></param>
        /// <returns></returns>
        public ActionResult ProcessEdit(JetSkiModel jetSki)
        {
            // Call the method to Update/Edit the product
            _jetSkiService.Update(jetSki);
            _logger.LogInformation("(Class: JetSkisController, Method: ProcessEdit has been called)");

            // Redirect back to the jetskis page
            return View("Index", _jetSkiService.getAllJetSkis());
        }


        /// <summary>
        /// This method displays the add jet ski form
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowAddForm()
        {
            _logger.LogInformation("(Class: JetSkisController, Method: ShowAddForm has been called)");

            // navigate to add jet ski page
            return View();
        }


        /// <summary>
        /// This method processes the add jet ski form. 
        /// This method takes the jet ski the user has made and adds it to the database and applcation.
        /// </summary>
        /// <param name="jetSki"></param>
        /// <returns></returns>
        public ActionResult ProcessAddJetSki(JetSkiModel jetSki)
        {
            // Call the method to add a JetSki
            _jetSkiService.AddJetSki(jetSki);
            _logger.LogInformation("(Class: JetSkisController, Method: ProcessAddJetSki has been called)");

            // Redirect back to the jet skis page with the newly created jet ski
            return View("Index", _jetSkiService.getAllJetSkis());
        }

    }
}
