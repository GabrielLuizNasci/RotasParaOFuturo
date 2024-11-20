using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotasParaOFuturo.Models
{
    [Table("Responsaveis")]
    public class Responsavel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }

        [Display(Name = "Nome do Responsavel: ")]
        [Required(ErrorMessage = "Campo nome é obrigatório...")]
        [StringLength(35, ErrorMessage = "Tamanho máximo 35 caracteres")]
        public string nome { get; set; }

        [Display(Name = "Data de Nascimento: ")]
        [Required(ErrorMessage = "Campo Data de Nascimento é obrigatório")]
        public DateTime aniversario { get; set; }

        [Display(Name = "CPF do Responsavel: ")]
        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [StringLength(14, ErrorMessage = "Tamanho máximo 14 caracteres")]
        public string cpf { get; set; }

        [Display(Name = "RG do Responsavel: ")]
        [Required(ErrorMessage = "Campo RG é obrigatório...")]
        [StringLength(14, ErrorMessage = "Tamanho máximo 14 caracteres")]
        public string rg { get; set; }

        [Display(Name = "Telefone do Responsavel: ")]
        [StringLength(20, ErrorMessage = "Tamanho máximo 20 caracteres")]
        public string tel { get; set; }

        [Display(Name = "Profissão: ")]
        [Required(ErrorMessage = "Campo obrigatório...")]
        [StringLength(35, ErrorMessage = "Tamanho máximo 35 caracteres")]
        public string profissao { get; set; }

        [Display(Name = "Renda Mensal: ")]
        [Required(ErrorMessage = "Campo obrigatório...")]
        [Range(0, double.MaxValue, ErrorMessage = "A renda mensal deve ser um valor positivo.")]
        public float renda { get; set; }

        [Display(Name = "Local de Trabalho: ")]
        [Required(ErrorMessage = "Campo obrigatório...")]
        [StringLength(35, ErrorMessage = "Tamanho máximo 35 caracteres")]
        public string local { get; set; }
    }



}