using FluentValidation;

namespace App.Volvo.Business.Models.Validations
{
    public class ModeloValidation : AbstractValidator<Modelo>
    {
        public ModeloValidation()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} Precisa ser preenchido")
                .Length(2, 10).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
