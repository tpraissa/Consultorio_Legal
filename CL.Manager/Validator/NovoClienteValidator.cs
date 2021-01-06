using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(100);
            RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Sexo).NotNull().NotEmpty().Must(IsMorF);
            RuleFor(x => x.Telefone).NotNull().NotEmpty().Matches("[1-9][0-9]{11}").WithMessage("Formato 11 números");
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        }


    private bool IsMorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
