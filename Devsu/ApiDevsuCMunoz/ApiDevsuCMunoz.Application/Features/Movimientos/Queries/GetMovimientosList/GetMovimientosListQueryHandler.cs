using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using ApiDevsuCMunoz.Domain;
using AutoMapper;
using MediatR;
using System.Collections.Generic;

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
            var movimientoList = _movimientoRepository.GetAllMovimientos(request._CuentaNumero);

            List<Movimiento> movimiento = new List<Movimiento>();

            foreach (var Movimiento in movimientoList)
            movimiento.Add(Movimiento);

            return _mapper.Map<List<MovimientosVM>>(movimiento);
        }
    }
}