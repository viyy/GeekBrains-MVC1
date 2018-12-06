﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.DomainModels.Models
{
    public class LoginViewModel
    {

            [Required]
            public string UserName { get; set; }

            [Required, DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }

            public string ReturnUrl { get; set; }
    }
}