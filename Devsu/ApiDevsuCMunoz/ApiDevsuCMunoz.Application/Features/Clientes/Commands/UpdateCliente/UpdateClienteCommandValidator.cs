using FluentValidation;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(200).WithMessage("{Nombre} no podra exceder los 200 caracteres");
            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(5).WithMessage("{Estado} no podra exceder los 5 caracteres");
        }
    }
}
