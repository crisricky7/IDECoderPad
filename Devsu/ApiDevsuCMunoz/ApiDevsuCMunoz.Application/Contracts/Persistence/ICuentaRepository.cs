using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface ICuentaRepository : IAsyncRepository<Cuenta>
    {
        Task<List<Cuenta>> GetClienteByCuentas(string identificacion);
        Task<InformeCuenta> GetInformeCuentas(string identificacion);
        public bool ValidaMovimientosAsync(Cuenta entity);
    }
}
