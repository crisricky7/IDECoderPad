using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Infrestructure.Persistence;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ApiDevsuCMunozDbContext _context;
        public ClienteRepository(ApiDevsuCMunozDbContext context) : base(context)
        {
            _context = context;
        }

        public RespuestaValidacionCliente ValidarCliente(Cliente cliente)
        {
            var clienteCuentas = _context!.Cuentas!.Where(c => c.ClienteId == cliente.Id).Count()>0;
            if (clienteCuentas){
                return new RespuestaValidacionCliente
                {
                    Status = "NOOK",
                    Message = "Error no se puede eliminar cliente ya que tiene cuentas vinculadas",
                    Cliente = null
                };
            }
            else {
                return new RespuestaValidacionCliente
                {
                    Status = "OK",
                    Message = null,
                    Cliente = null
                };
            }
        }
    }
}
