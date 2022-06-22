using FluentValidation;
using PruebaTecnica.Core.Entities;

namespace Pruebatecnica.Infraestructura.Validators
{
    public class BuildValidator : AbstractValidator<Build>
    {
        public BuildValidator()
        {
            RuleFor(build => build.Name)
                .NotNull()
                .Length(2, 256);


            RuleFor(build => build.Address)
            .NotNull()
            .Length(2, 256);


            RuleFor(build => build.Tower)
            .NotNull()
            .Length(1, 10);
        }
    }
}
