using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplate.Data.Dtos;

public class LoginUserDto
{
    [Required(ErrorMessage = "O campo de e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo de senha é obrigatório.")]
    [StringLength(100, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres.", MinimumLength = 6)]
    public string Password { get; set; }
}