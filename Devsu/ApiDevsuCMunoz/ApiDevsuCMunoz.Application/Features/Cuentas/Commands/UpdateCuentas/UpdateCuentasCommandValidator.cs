using FluentValidation;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.UpdateCuentas
{
    public class UpdateCuentasCommandValidator : AbstractValidator<UpdateCuentasCommand>
    {
        public UpdateCuentasCommandValidator()
        {
            RuleFor(p => p.Numero)
                .NotNull().WithMessage("{Nombre} no puede estar en blanco");
            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(5).WithMessage("{Estado} no podra exceder los 5 caracteres");
        }
    }
}
