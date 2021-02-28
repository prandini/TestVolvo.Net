using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Volvo.Business.Models.Validations
{
    public class CaminhaoValidation : AbstractValidator<Caminhao>
    {
        public CaminhaoValidation()
        {
            RuleFor(c => c.Chassi)
                .NotEmpty().WithMessage("O Campo {PropertyName} Precisa ser preenchido")
                .Length(17).WithMessage("O Campo {PropertyName} Precisa conter 17 caracteres");

            RuleFor(c => c.AnoFabricacao)
                .NotEmpty().WithMessage("O Campo {PropertyName} Precisa ser preenchido")
                .Equal((short)DateTime.Now.Year).WithMessage("O Campo {PropertyName} precisa ser o ano atual");

            RuleFor(c => c.AnoFabricacao.ToString())
                .Length(4).WithMessage("O Campo {PropertyName} precisa ser um ano valido")
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");


           RuleFor(c => c.AnoModelo.ToString())
                .Length(4).WithMessage("O Campo {PropertyName} precisa ser um ano valido")
                .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.AnoModelo)
                .NotEmpty().WithMessage("O Campo {PropertyName} Precisa ser preenchido")
                .GreaterThanOrEqualTo(c => c.AnoFabricacao).WithMessage("O Campo {PropertyName} tem que ter o valor maior ou igual ao ano de {ComparisonValue}");


        }
    }
}
