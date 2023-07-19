using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, RespuestaTransaccionMovimiento>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateMovimientoCommandHandler> _logger;

        public CreateMovimientoCommandHandler(IMovimientoRepository movimientoRepository, IMapper mapper, ILogger<CreateMovimientoCommandHandler> logger)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<RespuestaTransaccionMovimiento> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimientoEntity = _mapper.Map<Movimiento>(request);
            var respuesta = await _movimientoRepository.ValidaTransaccion(movimientoEntity);
            if (respuesta.Status.Equals("OK")){
                var newMovimiento = await _movimientoRepository.AddAsync(respuesta.Movimiento);
                _logger.LogInformation($"Movimiento {newMovimiento.Id} fue creado correctamente.");
                return new RespuestaTransaccionMovimiento
                {
                    Status = respuesta.Status,
                    Message = "Movimiento creado correctamente",
                    Movimiento = _mapper.Map<MovimientosVM>(newMovimiento)
                };
            }
            else {
                return new RespuestaTransaccionMovimiento
                {
                    Status = respuesta.Status,
                    Message = respuesta.Message,
                    Movimiento = null
                };
            }
            
        }
    }
}
