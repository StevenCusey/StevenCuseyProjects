using System.ComponentModel.DataAnnotations;


namespace CST323Milestone.Models
{
    public class UsersRegisterModel
    {
        // Class properites
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must be at least 2 characters long")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name must be at least 2 characters long")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "The username must be between 2 and 30 characters long")]
        public string Password { get; set; }

    }
}