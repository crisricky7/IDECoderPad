using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Queries.GetMovimientosList
{
    public class GetMovimientosListQuery : IRequest<List<MovimientosVM>>
    {
        public long _CuentaNumero  { get; set; }

        public GetMovimientosListQuery(long CuentaNumero)
        {
            _CuentaNumero = CuentaNumero;
        }
    }
}