using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Queries.GetMovimientosList
{
    public class GetMovimientosListQuery : IRequest<List<MovimientosVM>>
    {
        public long _id  { get; set; }

        public GetMovimientosListQuery(long id)
        {
            _id = id;
        }
    }
}