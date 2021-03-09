using System.ComponentModel.DataAnnotations;

namespace PresentataionHost.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string RetrunUrl { get; set; }
    }
}
