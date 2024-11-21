using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotasParaOFuturo.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Descricao: ")]
        public string Descricao { get; set; }


        [Required]
        [Display(Name = "Periodo: ")]
        public int Periodo { get; set; }

        [NotMapped]
        public string PeriodoFormatado
        {
            get
            {
                return Periodo switch
                {
                    1 => "Manhã",
                    2 => "Tarde",
                    3 => "Noite",
                    _ => "Não Especificado"
                };
            }
        }

        [Required]
        [Display(Name = "Total de Aulas: ")]
        public int TotalAulas { get; set; }
    }
}
