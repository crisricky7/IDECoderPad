using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Exceptions;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.DeleteCuentas
{
    public class DeleteCuentasCommandHandler : IRequestHandler<DeleteCuentasCommand, Unit>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCuentasCommandHandler> _logger;

        public DeleteCuentasCommandHandler(ICuentaRepository clienteRepository, IMapper mapper, ILogger<DeleteCuentasCommandHandler> logger)
        {
            _cuentaRepository = clienteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCuentasCommand request, CancellationToken cancellationToken)
        {
            var cuentaToDelete = await _cuentaRepository.GetByIdAsync(request.Numero);
            if (cuentaToDelete == null)
            {
                _logger.LogError($"No se encontro la cuenta con el número {request.Numero}");
                throw new NotFoundException(nameof(Cuenta), request.Numero);
            }
            await _cuentaRepository.DeleteAsync(cuentaToDelete);
            _logger.LogInformation($"La operación fue exitosa eliminando la cuenta {request.Numero}");
            return Unit.Value;
        }
    }
}