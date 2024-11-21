using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotasParaOFuturo.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição: ")]
        public string descricao { get; set; }
    
        [Required]
        [Display(Name = "Periodo: ")]
        public int periodo { get; set; }

        [NotMapped]
        public string periodoFormatado
        {
            get
            {
                return periodo switch
                {
                    1 => "Manhã",
                    2 => "Tarde",
                    3 => "Noite",
                    _ => "Não Especificado"
                };
            }
        }

        [Required]
        [Display(Name = "Atividade: ")]
        public Atividade atividade { get; set; }
        [Display(Name = "Atividade ID: ")]
        public int atividadeID { get; set; }

        // Propriedade para armazenar as matrículas associadas à turma
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
