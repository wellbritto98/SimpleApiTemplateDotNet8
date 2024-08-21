using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleApiTemplateDotNet8.Data.Dtos.Auth
{
    public class RegisterUserDto : IValidatableObject
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Nickname { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "A senha de confirmação deve ser igual à senha.")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Você deve concordar com os termos.")]
        public bool AgreeTerms { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != PasswordConfirmation)
            {
                yield return new ValidationResult("A senha de confirmação deve ser igual à senha.", new[] { nameof(PasswordConfirmation) });
            }

            if (!AgreeTerms)
            {
                yield return new ValidationResult("Você deve concordar com os termos.", new[] { nameof(AgreeTerms) });
            }
        }
    }
}