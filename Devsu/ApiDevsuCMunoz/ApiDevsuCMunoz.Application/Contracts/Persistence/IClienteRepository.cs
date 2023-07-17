using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        Task<Cliente> GetClienteByIdentificacion(string identificacion);
    }
}
