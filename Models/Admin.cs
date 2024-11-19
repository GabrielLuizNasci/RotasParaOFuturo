using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RotasParaOFuturo.Models
{
    public class Admin: IdentityUser
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Endereço: ")]
        public string Endereco { get; set; }

    }
}
