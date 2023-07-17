using ApiDevsuCMunoz.Application;
using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Domain;
using ApiDevsuCMunoz.Infrestructure.Persistence;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class MovimientoRepository : RepositoryBase<Movimiento>, IMovimientoRepository
    {
        public ApiDevsuCMunozDbContext _context;
        public MovimientoRepository(ApiDevsuCMunozDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<ResultadosAPI> RegistraTransaccion(long numCuenta, string tipo, double valor)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadosAPI> ValidarCupoDiario(long numCuenta, double valor)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadosAPI> ValidarSaldo(long numCuenta, double valor)
        {
            throw new NotImplementedException();
        }
    }
}
