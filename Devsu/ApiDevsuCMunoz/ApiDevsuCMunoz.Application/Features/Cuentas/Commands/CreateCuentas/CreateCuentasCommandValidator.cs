using FluentValidation;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.CreateCuentas
{
    public class CreateCuentasCommandValidator : AbstractValidator<CreateCuentasCommand>
    {
        public CreateCuentasCommandValidator()
        {
            RuleFor(p => p.Numero)
                .NotNull().WithMessage("{Numero} no puede estar en blanco");
        }
    }
}
