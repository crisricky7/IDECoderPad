using FluentValidation;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandValidator : AbstractValidator<UpdateMovimientoCommand>
    {
        public UpdateMovimientoCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{Nombre} no puede estar en blanco");
            RuleFor(p => p.Valor)
                .NotNull().WithMessage("{Valor} no puede estar en blanco");
        }
    }
}
