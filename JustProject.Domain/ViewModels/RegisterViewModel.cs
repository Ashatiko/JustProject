using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле 'Email' является обязательным")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Пароль' является обязательным")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Поле 'Подтверждение пароля' является обязательным")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
