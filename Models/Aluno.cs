using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotasParaOFuturo.Models
{
    [Table("Alunos")]
    public class Aluno
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
        [Display(Name = "Nascimento: ")]
        public string Nascimento { get; set; }

        [Required]
        [Display(Name = "Endereco: ")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "CPF: ")]
        public int CPF { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "RG: ")]
        public string RG { get; set; }

        [Required]
        [Display(Name = "Telefone: ")]
        public int Telefone { get; set; }

        [Required]
        [Display(Name = "Sexo: ")]
        public int Sexo { get; set; }

        [NotMapped]
        public string SexoFormatado
        {
            get
            {
                return Sexo switch
                {
                    1 => "Masculino",
                    2 => "Feminino",
                    3 => "Outro",
                    _ => "Não Especificado"
                };
            }
        }
    }
}
