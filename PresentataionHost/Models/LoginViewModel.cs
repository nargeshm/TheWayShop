﻿using System.ComponentModel.DataAnnotations;

namespace PresentataionHost.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string RetrunUrl { get; set; }
    }
}
