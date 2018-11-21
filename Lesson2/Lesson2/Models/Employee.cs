using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [Display(Name = "Имя")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2х и не более 200 символов")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательной")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения является обязательной")]
        public DateTime Birth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Отдел является обязательным")]
        public string Department { get; set; }
    }
}