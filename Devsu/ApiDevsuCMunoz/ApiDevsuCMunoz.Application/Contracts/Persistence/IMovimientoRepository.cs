using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IMovimientoRepository : IAsyncRepository<Movimiento>
    {
        Task<RespuestaValidacionMovimientos> ValidaTransaccion(Movimiento movimiento);
        RespuestaValidacionMovimientos ValidarSaldo(Movimiento movimiento);
        RespuestaValidacionMovimientos ValidarCupoDiario(Movimiento movimiento);
        List<Movimiento> GetAllMovimientos(long numCuenta);


    }
}
