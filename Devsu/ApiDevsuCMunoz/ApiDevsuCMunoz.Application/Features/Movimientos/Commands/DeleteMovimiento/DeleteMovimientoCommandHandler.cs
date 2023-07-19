using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand, Unit>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteMovimientoCommandHandler> _logger;

        public DeleteMovimientoCommandHandler(IMovimientoRepository movimientoRepository, IMapper mapper, ILogger<DeleteMovimientoCommandHandler> logger)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _movimientoRepository.GetByIdAsync(request.Id);
            if (clienteToDelete == null)
            {
                _logger.LogError($"No se encontro el movimiento con Id {request.Id}");
                throw new NotFoundException(nameof(Movimiento), request.Id);
            }
            await _movimientoRepository.DeleteAsync(clienteToDelete);
            _logger.LogInformation($"La operación fue exitosa eliminando el movimiento con Id {request.Id}");
            return Unit.Value;
        }
    }
}