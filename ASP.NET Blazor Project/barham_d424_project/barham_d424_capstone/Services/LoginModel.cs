﻿using System.ComponentModel.DataAnnotations;

namespace barham_d424_capstone.Services
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; } = string.Empty;
    }
}
