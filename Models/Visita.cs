
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotasParaOFuturo.Models
{
    [Table("Visitas")]
    public class Visita
    {
        //public enum Status { Aprovada, Pendente, Desaprovada }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }


        [Display(Name = "Responsavel: ")]
        public Responsavel responsavel { get; set; }


        [Display(Name = "Responsavel: ")]
        public int responsavelID { get; set; }


        [Display(Name = "Data da Visita: ")]
        [Required(ErrorMessage = "Campo Data é obrigatório")]
        public DateTime datavisita { get; set; }


        [Display(Name = "Descrição: ")]
        [StringLength(45, ErrorMessage = "Tamanho máximo 45 caracteres")]
        public string descricao { get; set; }


        [Required]
        [Display(Name = "Status da Visita: ")]
        public int status { get; set; }

        [NotMapped]
        public string StatusFormatado
        {
            get
            {
                return status switch
                {
                    1 => "Aprovado",
                    2 => "Pendente",
                    3 => "Desaprovado",
                    _ => "Não Especificado"
                };
            }
        }

    }
}