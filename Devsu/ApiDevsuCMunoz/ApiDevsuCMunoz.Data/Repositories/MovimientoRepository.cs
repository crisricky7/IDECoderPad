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

        public List<Movimiento> GetAllMovimientos(long numCuenta)
        {
            return _context!.Movimientos!.Where(x => x.CuentaNumero == numCuenta).ToList();
        }

        public Task<ResultadosAPI> RegistraTransaccion(long numCuenta, string tipo, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadosAPI> ValidarCupoDiario(long numCuenta, decimal valor)
        {
            throw new NotImplementedException();
        }

        public Task<ResultadosAPI> ValidarSaldo(long numCuenta, decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
