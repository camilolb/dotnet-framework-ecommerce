using System;
using FluentValidation;
using PruebaTecnica.Core.Entities;

namespace Pruebatecnica.Infraestructura.Validators
{
    public class DepartamentValidator : AbstractValidator<Departament>
    {
        public DepartamentValidator()
        {
            RuleFor(dep => dep.Number)
                .NotNull()
                .Length(1, 10);

            RuleFor(dep => dep.OwerId)
            .NotNull();

            RuleFor(dep => dep.BuildId)
            .NotNull();

            RuleFor(dep => dep.Price)
            .NotEqual(0)
            .NotNull();

        }
    }
}
