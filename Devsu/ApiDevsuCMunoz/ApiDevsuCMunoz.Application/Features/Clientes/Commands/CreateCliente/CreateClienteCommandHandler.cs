using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.CreaCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, RespuestaTransaccionCliente>
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

        public async Task<RespuestaTransaccionCliente> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clienteEntity = _mapper.Map<Cliente>(request);

                var newCliente = await _clienteRepository.AddAsync(clienteEntity);
                _logger.LogInformation($"Cliente {newCliente.Id} fue creado correctamente.");
                return new RespuestaTransaccionCliente
                {
                    Status = "OK",
                    Message = null,
                    Cliente = _mapper.Map<ClientesVM>(newCliente)
                };
            }
            catch (Exception ex) {
                return new RespuestaTransaccionCliente
                {
                    Status = "NOOK",
                    Message = ex.Message,
                    Cliente = null
                };

            }
        }
    }
}
