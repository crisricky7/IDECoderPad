using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand, RespuestaTransaccionMovimiento>
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

        public async Task<RespuestaTransaccionMovimiento> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            try {
                var clienteToDelete = await _movimientoRepository.GetByIdAsync(request.Id);
                if (clienteToDelete == null){
                    _logger.LogError($"No se encontro el movimiento con Id {request.Id}");
                    return new RespuestaTransaccionMovimiento
                    {
                        Status = "NOOK",
                        Message = "No se encontro el movimiento que desea eliminar",
                        Movimiento = null,
                    };
                }
                else {
                    await _movimientoRepository.DeleteAsync(clienteToDelete);
                    _logger.LogInformation($"La operación fue exitosa eliminando el movimiento con Id {request.Id}");
                    return new RespuestaTransaccionMovimiento
                    {
                        Status = "OK",
                        Message = "La operación fue exitosa eliminando el movimiento con Id"+request.Id,
                        Movimiento = null,
                    };
                }
            }
            catch (Exception ex) {
                return new RespuestaTransaccionMovimiento
                {
                    Status = "NOOK",
                    Message = ex.Message,
                    Movimiento = null,
                };
            }
        }
    }
}