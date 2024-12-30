using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using CST323Milestone.Models;
using CST323Milestone.Services.DataAccess;
using CST323Milestone.Controllers;


namespace CST323Milestone.Services.Business
{
    public class JetSkiService
    {
        // Class Level Variables
        private readonly ILogger<JetSkiService> _logger;
        private readonly JetSkiDAO _jetSkiDAO;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected JetSkiDAO
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jetSkiDAO"></param>
        public JetSkiService(ILogger<JetSkiService> logger, JetSkiDAO jetSkiDAO)
        {
            _logger = logger;
            _jetSkiDAO = jetSkiDAO;

        }



        /// <summary>
        /// Get all Jet Skis from the database
        /// </summary>
        /// <returns></returns>
        public List<JetSkiModel> getAllJetSkis()
		{
			List<JetSkiModel> listOfJetSkis = new List<JetSkiModel>();

			listOfJetSkis = _jetSkiDAO.GetAllJetSkis();

            _logger.LogInformation("(Class: JetSkiService, Method: getAllJetSkis has been called)");

            return listOfJetSkis;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        public int DeleteJetSki(int id)
        {
            _logger.LogInformation("(Class: JetSkiService, Method: DeleteJetSki has been called)");

            return _jetSkiDAO.DeleteJetSki(id);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        public JetSkiModel GetJetSkiById(int id)
        {
            _logger.LogInformation("(Class: JetSkiService, Method: GetJetSkiById has been called)");


            return _jetSkiDAO.GetJetSkiById(id);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="jetSki"></param>
		/// <returns></returns>
        public int Update(JetSkiModel jetSki)
		{
            _logger.LogInformation("(Class: JetSkiService, Method: Update has been called)");

            return _jetSkiDAO.Update(jetSki);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newJetSki"></param>
		/// <returns></returns>
        public bool AddJetSki(JetSkiModel newJetSki)
		{
            _logger.LogInformation("(Class: JetSkiService, Method: AddJetSki has been called)");

            return _jetSkiDAO.AddJetSki(newJetSki);
		}
    }
}
