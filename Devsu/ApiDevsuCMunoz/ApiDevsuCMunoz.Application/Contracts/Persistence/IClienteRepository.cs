using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IClienteRepository : IAsyncRepository<Cliente>
    {
        RespuestaValidacionCliente ValidarCliente(Cliente cliente);
    }
}
