using FluentValidation;
using Lafage.Sales.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lafage.Sales.Application.Validators
{
    public class PersonaDtoValidator : AbstractValidator<PersonaDto>
    {
        public PersonaDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(50);

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio")
                .MaximumLength(50);

            RuleFor(x => x.Direccion)
                .MaximumLength(100);

            RuleFor(x => x.Telefono)
                .Matches(@"^\+?[0-9\s\-]{7,20}$")
                .When(x => !string.IsNullOrEmpty(x.Telefono))
                .WithMessage("Teléfono inválido");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Formato de email inválido")
                .MaximumLength(100)
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.NumeroIdentificacion)
                .MaximumLength(20);
        }
    }

}
