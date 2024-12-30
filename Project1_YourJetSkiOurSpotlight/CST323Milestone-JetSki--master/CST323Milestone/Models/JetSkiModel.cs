namespace CST323Milestone.Models
{
	public class JetSkiModel
	{
		// Class Properties
		public int Id { get; set; }

        public string Image { get; set; }

        public string Make { get; set; }

		public string Model { get; set; }

        public string Color { get; set; }

		public int Year { get; set; }

		public int Price { get; set; }

		/// <summary>
		/// Non-Default Constructor
		/// </summary>
		/// <param name="id"></param>
		/// <param name="image"></param>
		/// <param name="make"></param>
		/// <param name="model"></param>
		/// <param name="color"></param>
		/// <param name="year"></param>
		/// <param name="price"></param>
		public JetSkiModel(int id, string image, string make, string model, string color, int year, int price)
		{
			Id = id;
			Image = image;
			Make = make;
			Model = model;
			Color = color;
			Year = year;
			Price = price;
		}


		/// <summary>
		/// Default constructor
		/// </summary>
        public JetSkiModel()
        {
        }
    }
}
