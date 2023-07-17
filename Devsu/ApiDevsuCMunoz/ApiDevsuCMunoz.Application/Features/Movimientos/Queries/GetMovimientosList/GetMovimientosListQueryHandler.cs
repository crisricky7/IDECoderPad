using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using AutoMapper;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Queries.GetMovimientosList
{
    public class GetMovimientosListQueryHandler : IRequestHandler<GetMovimientosListQuery, List<MovimientosVM>>
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IMapper _mapper;

        public GetMovimientosListQueryHandler(IMovimientoRepository movimientoRepository, IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
        }

        public async Task<List<MovimientosVM>> Handle(GetMovimientosListQuery request, CancellationToken cancellationToken)
        {
            var movimientoList = await _movimientoRepository.GetByIdAsync(request._id);

            return _mapper.Map<List<MovimientosVM>>(movimientoList);
        }
    }
}