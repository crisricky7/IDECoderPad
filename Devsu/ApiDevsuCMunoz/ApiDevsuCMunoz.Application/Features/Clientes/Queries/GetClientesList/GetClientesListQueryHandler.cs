using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using AutoMapper;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Queries.GetClientesList
{
    public class GetClientesListQueryHandler : IRequestHandler<GetClientesListQuery, List<ClientesVM>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetClientesListQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientesVM>> Handle(GetClientesListQuery request, CancellationToken cancellationToken)
        {
            var clienteList = await _clienteRepository.GetClienteByIdentificacion(request._Identificacion);

            return _mapper.Map<List<ClientesVM>>(clienteList);
        }
    }
}
