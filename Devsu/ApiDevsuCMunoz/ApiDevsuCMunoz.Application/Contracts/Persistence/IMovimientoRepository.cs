using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IMovimientoRepository : IAsyncRepository<Movimiento>
    {
        Task<ResultadosAPI> RegistraTransaccion(long numCuenta, string tipo, double valor);
        Task<ResultadosAPI> ValidarSaldo(long numCuenta, double valor);
        Task<ResultadosAPI> ValidarCupoDiario(long numCuenta, double valor);

    }
}
