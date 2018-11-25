using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WebStore.Models
{
    public class AccountViewModel
    {
        [Required, MaxLength(256), Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password)), Display(Name = "Повторите пароль")]
        public string ConfirmPassword { get; set; }

    }
}