using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RotasParaOFuturo.Models
{
    [Table("Parceiros")]
    public class Parceiro
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
        [StringLength(40)]
        [Display(Name = "Descrição: ")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data de Cadastro: ")]
        public DateTime DataMatricula { get; set; }

    }
}