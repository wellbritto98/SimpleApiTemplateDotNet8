using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos;

public class UpdateModeloReceituarioDto : BaseDto
{
    
        public string NomeInstituicao { get; set; }
        public string EnderecoInstituicao { get; set; }
        public byte[] ImagemInstituicao { get; set; }
        public string NomePaciente { get; set; }
        public string NomeProfissional { get; set; }
        public DateTime Data { get; set; }
        public string Receita { get; set; }
}
