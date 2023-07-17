using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.CreateCuentas
{
    public class CreateCuentasCommandHandler : IRequestHandler<CreateCuentasCommand, long>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCuentasCommandHandler> _logger;

        public CreateCuentasCommandHandler(ICuentaRepository cuentaRepository, IMapper mapper, ILogger<CreateCuentasCommandHandler> logger)
        {
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<long> Handle(CreateCuentasCommand request, CancellationToken cancellationToken)
        {
            var cuentaEntity = _mapper.Map<Cuenta>(request);
            var newCuenta = await _cuentaRepository.AddAsync(cuentaEntity);
            _logger.LogInformation($"Cuenta {newCuenta.Numero} fue creado correctamente.");

            return newCuenta.Numero;
        }
    }
}
