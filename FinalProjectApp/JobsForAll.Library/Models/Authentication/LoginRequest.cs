using System.ComponentModel.DataAnnotations;

namespace JobsForAll.Library.Models.Authentication
{
    public class LoginRequest
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
