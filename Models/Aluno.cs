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


        [Display(Name = "Data da Visita: ")]
        [Required(ErrorMessage = "Campo Data é obrigatório")]
        public DateTime Nascimento { get; set; }




        [Required]
        [Display(Name = "Endereco: ")]
        public string Endereco { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 11)]  // CPF com 11 ou 14 caracteres (com ou sem pontos e hífen)
        [RegularExpression(@"^\d{3}(\.\d{3}){0,2}(-\d{2})?$", ErrorMessage = "O CPF deve estar no formato XXX.XXX.XXX-XX ou apenas números.")]
        [Display(Name = "CPF: ")]
        public string CPF { get; set; }


        [Required]
        [StringLength(12, MinimumLength = 7)]  // RG com 7 a 12 caracteres (com ou sem pontos e hífen)
        [RegularExpression(@"^\d{1,2}(\.\d{3}){0,2}(-\d{1,2})?$", ErrorMessage = "O RG deve estar no formato XX.XXX.XXX-X ou apenas números.")]
        [Display(Name = "RG: ")]
        public string RG { get; set; }



        [Required]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "O número de telefone deve ter entre 10 e 15 caracteres.")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4,5}[-\s]?\d{4}$", ErrorMessage = "Formato de telefone inválido.")]
        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }


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
