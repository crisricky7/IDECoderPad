using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, long>
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

        public async Task<long> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimientoEntity = _mapper.Map<Movimiento>(request);
            var newMovimiento = await _movimientoRepository.AddAsync(movimientoEntity);
            _logger.LogInformation($"Movimiento {newMovimiento.Id} fue creado correctamente.");

            return newMovimiento.Id;
        }
    }
}
