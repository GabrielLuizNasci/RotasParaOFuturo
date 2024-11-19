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
        [Display(Name ="Descrição: ")]
        public string descricao { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Periodo: ")]
        public string periodo { get; set; }

        [Display(Name = "Atividade: ")]
        [StringLength(35)]
        public Atividade atividade {get; set; }
        [Display(Name = "Atividade: ")]
        public int atividadeID { get; set; }

    }
}
