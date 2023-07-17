using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper, ILogger<DeleteClienteCommandHandler> logger)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _clienteRepository.GetByIdAsync(request.Id);
            if (clienteToDelete == null)
            {
                _logger.LogError($"No se encontro el cliente identificacion {request.Id}");
                throw new NotFoundException(nameof(Cliente), request.Id);
            }
            await _clienteRepository.DeleteAsync(clienteToDelete);
            _logger.LogInformation($"La operación fue exitosa eliminando el cliente {request.Id}");
            return Unit.Value;
        }
    }
}