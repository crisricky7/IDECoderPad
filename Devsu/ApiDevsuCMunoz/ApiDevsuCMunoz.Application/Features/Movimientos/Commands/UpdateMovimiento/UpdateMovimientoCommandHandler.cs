using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand, RespuestaTransaccionMovimiento>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateMovimientoCommandHandler> _logger;

        public UpdateMovimientoCommandHandler(IMovimientoRepository movimientoRepository, IMapper mapper, ILogger<UpdateMovimientoCommandHandler> logger)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<RespuestaTransaccionMovimiento> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
        {
            try {
                var clienteToUpdate = await _movimientoRepository.GetByIdAsync(request.Id);
                if (clienteToUpdate == null)
                {
                    _logger.LogError($"No se encontro el movimiento con Id {request.Id}");
                    return new RespuestaTransaccionMovimiento
                    {
                        Status = "NOOK",
                        Message = "No se encontro el movimiento que desea actualizar",
                        Movimiento = null,
                    };
                }
                else
                {
                    _mapper.Map(request, clienteToUpdate, typeof(UpdateMovimientoCommand), typeof(Movimiento));
                    await _movimientoRepository.UpdateAsync(clienteToUpdate);
                    _logger.LogInformation($"La operación fue exitosa actualizando el movimiento con Id {request.Id}");
                    return new RespuestaTransaccionMovimiento
                    {
                        Status = "OK",
                        Message = "La operación fue exitosa actualizando el movimiento con Id" + request.Id,
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