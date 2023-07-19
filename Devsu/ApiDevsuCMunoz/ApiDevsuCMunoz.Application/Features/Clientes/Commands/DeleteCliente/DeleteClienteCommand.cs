using ApiDevsuCMunoz.Application.Models;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<RespuestaTransaccionCliente>
    {
        public long Id { get; set; }
    }
}
