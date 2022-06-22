using System;
using FluentValidation;
using PruebaTecnica.Core.Entities;

namespace Pruebatecnica.Infraestructura.Validators
{
    public class OwnerValidator : AbstractValidator<Owner>
    {
        public OwnerValidator()
        {
            RuleFor(own => own.FullName)
                .NotNull()
                .Length(1, 256);
        }
    }
}
