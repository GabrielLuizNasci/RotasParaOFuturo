
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RotasParaOFuturo.Models;

namespace RotasParaOFuturo.Models
{
    [Table("Professores")]
    public class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }



        [Display(Name = "Parceiro: ")]
        public Parceiro parceiro { get; set; }


        [Display(Name = "Parceiro: ")]
        public int parceiroID { get; set; }
    }
}
