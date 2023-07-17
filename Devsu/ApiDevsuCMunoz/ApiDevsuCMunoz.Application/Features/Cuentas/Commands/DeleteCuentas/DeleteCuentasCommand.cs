using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.DeleteCuentas
{
    public class DeleteCuentasCommand : IRequest<Unit>
    {
        public long Numero { get; set; }
    }
}
