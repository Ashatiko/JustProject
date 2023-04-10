using System.ComponentModel.DataAnnotations;

namespace JustProject.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле 'Email' является обязательным")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле 'Пароль' является обязательным")]
        public string Password { get; set; }
    }
}
