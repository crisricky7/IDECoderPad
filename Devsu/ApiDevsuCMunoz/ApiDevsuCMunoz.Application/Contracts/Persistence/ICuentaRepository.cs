using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface ICuentaRepository : IAsyncRepository<Cuenta>
    {
        public bool ValidaMovimientosAsync(Cuenta entity);
    }
}
