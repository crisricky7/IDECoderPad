using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IMovimientoRepository : IAsyncRepository<Movimiento>
    {
        Task<ResultadosAPI> RegistraTransaccion(long numCuenta, string tipo, decimal valor);
        Task<ResultadosAPI> ValidarSaldo(long numCuenta, decimal valor);
        Task<ResultadosAPI> ValidarCupoDiario(long numCuenta, decimal valor);
        List<Movimiento> GetAllMovimientos(long numCuenta);


    }
}
