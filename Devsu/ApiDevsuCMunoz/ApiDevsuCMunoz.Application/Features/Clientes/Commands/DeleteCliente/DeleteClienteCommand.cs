using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
