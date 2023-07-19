using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommand : IRequest<Unit>
    {
        public long Id { get; set; }

    }
}
