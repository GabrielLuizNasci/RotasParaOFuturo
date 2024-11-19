using System.ComponentModel.DataAnnotations;

namespace RotasParaOFuturo.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembre-se de Mim")]
        public bool RememberMe { get; set; }
    }
}
