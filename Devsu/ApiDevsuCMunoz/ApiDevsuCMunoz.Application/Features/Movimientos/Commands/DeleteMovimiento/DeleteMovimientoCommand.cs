using ApiDevsuCMunoz.Application.Models;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommand : IRequest<RespuestaTransaccionMovimiento>
    {
        public long Id { get; set; }

    }
}
