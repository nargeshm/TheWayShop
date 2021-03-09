using System.ComponentModel.DataAnnotations;

namespace PresentataionHost.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
                    
    }
}
