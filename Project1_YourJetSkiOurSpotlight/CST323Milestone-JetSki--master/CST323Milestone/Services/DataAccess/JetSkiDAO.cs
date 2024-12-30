using CST323Milestone.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using CST323Milestone.Services.Data;
using CST323Milestone.Services.Business;

namespace CST323Milestone.Services.DataAccess
{
	public class JetSkiDAO
	{
        // Class Level Variables
        private readonly ILogger<JetSkiDAO> _logger;
        private readonly JetSkiData _jetSkiData;

        /// <summary>
        /// ASP.NET Cores built in logger, and injected JetSkiData
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="jetSkiData"></param>
        public JetSkiDAO(ILogger<JetSkiDAO> logger, JetSkiData jetSkiData)
        {
            _logger = logger;
            _jetSkiData = jetSkiData;

        }


        /// <summary>
        /// Gets all jet skis
        /// </summary>
        /// <returns></returns>
        public List<JetSkiModel> GetAllJetSkis()
        {
            return _jetSkiData.GetAllJetSkis();
        }

        /// <summary>
        /// deletes a jet ski
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteJetSki(int id)
        {
            _logger.LogInformation("(Class: JetSkiDAO, Method: DeleteJetSki has been called)");

            return _jetSkiData.DeleteJetSki(id);
        }

        /// <summary>
        /// Get a jet ski by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JetSkiModel GetJetSkiById(int id)
        {
            _logger.LogInformation("(Class: JetSkiDAO, Method: GetJetSkiById has been called)");


            return _jetSkiData.GetJetSkiById(id);
        }

        /// <summary>
        /// update a jet ski
        /// </summary>
        /// <param name="jetSki"></param>
        /// <returns></returns>
        public int Update(JetSkiModel jetSki)
        {
            _logger.LogInformation("(Class: JetSkiDAO, Method: Update has been called)");


            return _jetSkiData.Update(jetSki);
        }

        /// <summary>
        /// add a jet ski
        /// </summary>
        /// <param name="newJetSki"></param>
        /// <returns></returns>
        public bool AddJetSki(JetSkiModel newJetSki)
        {
            _logger.LogInformation("(Class: JetSkiDAO, Method: AddJetSki has been called)");

            return _jetSkiData.AddJetSki(newJetSki);
        }


    }
}
