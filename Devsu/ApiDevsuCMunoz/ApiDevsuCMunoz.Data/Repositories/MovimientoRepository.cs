using ApiDevsuCMunoz.Application;
using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Models;
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

        public async Task<RespuestaValidacionMovimientos> ValidaTransaccion(Movimiento movimiento)
        {
            try
            {
                if (movimiento.Tipo.Equals("Debito"))
                {
                    RespuestaValidacionMovimientos respuesta = ValidarCupoDiario(movimiento);
                    if (respuesta.Status.Equals("OK"))
                    {
                        respuesta = ValidarSaldo(movimiento);
                        if (respuesta.Status.Equals("OK"))
                        {

                            movimiento.Saldo = respuesta.Movimiento.Saldo;
                            movimiento.Valor = movimiento.Valor * -1;

                            return new RespuestaValidacionMovimientos
                            {
                                Status = "OK",
                                Message = null,
                                Movimiento = movimiento
                            };
                        }
                        else {
                            return respuesta;
                        }
                    }
                    else
                    {
                        return respuesta;
                    }

                }
                else
                {
                    var datos = _context!.Cuentas!.Where(x => x.Numero == movimiento.CuentaNumero).FirstOrDefault();
                    movimiento.Saldo = (decimal)(datos.SaldoInicial + movimiento.Valor);
                    return new RespuestaValidacionMovimientos
                    {
                        Status = "OK",
                        Message = null,
                        Movimiento = movimiento
                    };
                }
            }
            catch (Exception ex) {
                return new RespuestaValidacionMovimientos
                {
                    Status = "NOOK",
                    Message = ex.Message,
                    Movimiento = null
                };
            }
        }

        public RespuestaValidacionMovimientos ValidarCupoDiario(Movimiento movimiento)
        {
            try 
            {
                //var datos = _context!.Movimientos!.Where(x => x.CuentaNumero == movimiento.CuentaNumero && x.Fecha == DateTime.Today).ToList();
                var today = DateTime.Today;
                var datos = _context.Movimientos.Where(x => x.CuentaNumero == movimiento.CuentaNumero &&
                                          x.Fecha.Value.Year == today.Year &&
                                          x.Fecha.Value.Month == today.Month &&
                                          x.Fecha.Value.Day == today.Day).ToList();


                decimal sumValor =0;
                foreach (var dato in datos) {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                    if (dato.Tipo.Equals("Debito"))
                    sumValor = sumValor + dato.Valor;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                }
                if (Math.Abs(sumValor) + movimiento.Valor >= 1000) {
                    return new RespuestaValidacionMovimientos
                    {
                        Status = "NOOK",
                        Message = "Monto diario Excedido"
                    };
                }
                return new RespuestaValidacionMovimientos
                {
                    Status = "OK",
                    Message = null
                };
            }
            catch (Exception ex)
            {
                return new RespuestaValidacionMovimientos
                {
                    Status = "NOOK",
                    Message = ex.ToString()
                };
            }
        }

        public RespuestaValidacionMovimientos ValidarSaldo(Movimiento movimiento)
        {
            try
            {
                var datos = _context!.Cuentas!.Where(x => x.Numero == movimiento.CuentaNumero).FirstOrDefault();

                if (datos.SaldoInicial - movimiento.Valor < 0)
                {
                    return new RespuestaValidacionMovimientos
                    {
                        Status = "NOOK",
                        Message = "Saldo no disponible para retiro"
                    };
                }
                else
                {
                    movimiento.Saldo = (decimal)(datos.SaldoInicial - movimiento.Valor);
                    return new RespuestaValidacionMovimientos
                    {
                        Movimiento = movimiento,
                        Status = "OK",
                        Message = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new RespuestaValidacionMovimientos
                {
                    Status = "NOOK",
                    Message = ex.ToString()
                };
            }
        }

    }
}
