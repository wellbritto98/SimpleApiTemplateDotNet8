using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class ReadModeloReceituarioDto : BaseDto
{
    public int Id { get; set; } 
        public string NomeInstituicao { get; set; }
        public string EnderecoInstituicao { get; set; }
        public byte[] ImagemInstituicao { get; set; }
        public string NomePaciente { get; set; }
        public string NomeProfissional { get; set; }
        public DateTime Data { get; set; }
        public string Receita { get; set; }
}
