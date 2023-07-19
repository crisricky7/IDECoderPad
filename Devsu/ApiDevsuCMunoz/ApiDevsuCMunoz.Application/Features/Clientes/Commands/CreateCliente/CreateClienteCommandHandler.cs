using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.CreaCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, long>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateClienteCommandHandler> _logger;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, ILogger<CreateClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteEntity = _mapper.Map<Cliente>(request);
            var newCliente = await _clienteRepository.AddAsync(clienteEntity);
            _logger.LogInformation($"Cliente {newCliente.Id} fue creado correctamente.");

            return newCliente.Id;
        }
    }
}
