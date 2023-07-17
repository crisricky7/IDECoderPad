using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Queries.GetCuentasList
{
    public class GetCuentasListQuery : IRequest<List<CuentasVM>>
    {
        public long _Numero { get; set; }

        public GetCuentasListQuery(long numero)
        {
            _Numero = numero;
        }
    }
}
