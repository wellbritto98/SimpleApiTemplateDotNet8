using SimpleApiTemplateDotNet8.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApiTemplateDotNet8.Models;

public class ModeloReceituario : BaseEntity 
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string NomeInstituicao { get; set; }
        public string EnderecoInstituicao { get; set; }
        public byte[] ImagemInstituicao { get; set; }
        public string NomePaciente { get; set; }
        public string NomeProfissional { get; set; }
        public DateTime Data { get; set; }
        public string Receita { get; set; }
}
