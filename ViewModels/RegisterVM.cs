using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;

namespace RotasParaOFuturo.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [Display(Name = "Nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas precisam ser iguais")]
        [Display(Name = "Confirme sua senha")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.MultilineText)]
        public string Endereco { get; set; }
    }
}
