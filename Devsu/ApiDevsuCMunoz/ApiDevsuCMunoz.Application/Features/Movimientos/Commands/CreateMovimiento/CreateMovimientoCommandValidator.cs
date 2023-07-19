using FluentValidation;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientoCommandValidator : AbstractValidator<CreateMovimientoCommand>
    {
        public CreateMovimientoCommandValidator()
        {
            RuleFor(p => p.CuentaNumero)
                .NotNull().WithMessage("{CuentaNumero} no puede estar en blanco");
            RuleFor(p => p.Valor)
                .NotNull().WithMessage("{Valor} no puede estar en blanco")
                .When(p => p.Valor > 1000).WithMessage("No puede retirar un valor mayor a 1000");
            RuleFor(p => p.Tipo)
                .NotNull().WithMessage("{Tipo} no puede estar en blanco");
        }
    }
}
