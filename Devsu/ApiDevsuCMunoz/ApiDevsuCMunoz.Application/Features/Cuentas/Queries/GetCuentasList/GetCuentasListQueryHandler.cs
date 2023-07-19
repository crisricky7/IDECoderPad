using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using AutoMapper;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Queries.GetCuentasList
{
    public class GetCuentasListQueryHandler : IRequestHandler<GetCuentasListQuery, CuentasVM>
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;

        public GetCuentasListQueryHandler(ICuentaRepository clienteRepository, IMapper mapper)
        {
            _cuentaRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<CuentasVM> Handle(GetCuentasListQuery request, CancellationToken cancellationToken)
        {
            var cuentaList = await _cuentaRepository.GetByIdAsync(request._Numero);

            return _mapper.Map<CuentasVM>(cuentaList);
        }
    }
}