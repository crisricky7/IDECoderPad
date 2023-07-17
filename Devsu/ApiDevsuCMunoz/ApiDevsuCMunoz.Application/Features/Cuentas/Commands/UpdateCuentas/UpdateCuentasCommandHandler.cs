using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.UpdateCuentas
{
    public class UpdateCuentasCommandHandler : IRequestHandler<UpdateCuentasCommand, Unit>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCuentasCommandHandler> _logger;

        public UpdateCuentasCommandHandler(ICuentaRepository cuentaRepository, IMapper mapper, ILogger<UpdateCuentasCommandHandler> logger)
        {
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateCuentasCommand request, CancellationToken cancellationToken)
        {
            var cuentaToUpdate = await _cuentaRepository.GetByIdAsync(request.Numero);
            if (cuentaToUpdate == null)
            {
                _logger.LogError($"No se encontro el número de cuenta {request.Numero}");
                throw new NotFoundException(nameof(Cuenta), request.Numero);
            }
            _mapper.Map(request, cuentaToUpdate, typeof(UpdateCuentasCommand), typeof(Cuenta));
            await _cuentaRepository.UpdateAsync(cuentaToUpdate);
            _logger.LogInformation($"La operación fue exitosa actualizando el número de cuenta {request.Numero}");
            return Unit.Value;
        }
    }
}