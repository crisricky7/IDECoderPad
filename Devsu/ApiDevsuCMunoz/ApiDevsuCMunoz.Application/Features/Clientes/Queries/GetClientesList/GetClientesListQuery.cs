using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Queries.GetClientesList
{
    public class GetClientesListQuery : IRequest<List<ClientesVM>>
    {
        public string _Identificacion { get; set; } = String.Empty;

        public GetClientesListQuery(string identificacion) { 
            _Identificacion = identificacion ?? throw new ArgumentNullException(nameof(identificacion));
        }
    }
}
