using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Queries.GetClientesList
{
    public class GetClientesListQuery : IRequest<ClientesVM>
    {
        public long Id { get; set; }

        public GetClientesListQuery(long id) {
            Id = id;
        }
    }
}
