
using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Models;
using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Infrestructure.Persistence;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class CuentaRepository : RepositoryBase<Cuenta>, ICuentaRepository
    {
        public ApiDevsuCMunozDbContext _context;
        public CuentaRepository(ApiDevsuCMunozDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Cuenta>> GetClienteByCuentas(string identificacion)
        {
            throw new NotImplementedException();
        }

        public Task<InformeCuenta> GetInformeCuentas(string identificacion)
        {
            throw new NotImplementedException();
        }
    }
}
