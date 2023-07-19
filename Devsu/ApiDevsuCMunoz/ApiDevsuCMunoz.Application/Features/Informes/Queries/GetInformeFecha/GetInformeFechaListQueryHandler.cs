using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Informes.VModels;
using AutoMapper;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Informes.Queries.GetInformeFecha
{
    public class GetInformeFechaListQueryHandler : IRequestHandler<GetInformeFechaListQuery, InformeCuentaVM>
    {
        private readonly IInformeRepository _informeRepository;
        private readonly IMapper _mapper;

        public GetInformeFechaListQueryHandler(IInformeRepository informeRepository, IMapper mapper)
        {
            _informeRepository = informeRepository;
            _mapper = mapper;
        }

        public async Task<InformeCuentaVM> Handle(GetInformeFechaListQuery request, CancellationToken cancellationToken)
        {
            var result = await _informeRepository.GeneraInformeCliente(request._ClienteID, request._FechaInicio, request._FechaFin);
            return result;
        }
    }
}
