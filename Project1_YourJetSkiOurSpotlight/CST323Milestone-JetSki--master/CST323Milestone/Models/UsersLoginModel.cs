namespace CST323Milestone.Models
{
    public class UsersLoginModel
    {
        // Class Properties
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Non-Default Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public UsersLoginModel(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
		public UsersLoginModel()
		{
		}
	}
}
