using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToUpdate = await _clienteRepository.GetClienteByIdentificacion(request.Identificacion);
            if (clienteToUpdate == null)
            {
                _logger.LogError($"No se encontro el cliente identificacion {request.Identificacion}");
                throw new NotFoundException(nameof(Cliente), request.Identificacion);
            }
            _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));
            await _clienteRepository.UpdateAsync(clienteToUpdate);
            _logger.LogInformation($"La operación fue exitosa actualizando el cliente {request.Identificacion}");
            return Unit.Value;
        }
    }
}