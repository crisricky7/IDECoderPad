using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Models
{
    public class RespuestaValidacionCliente
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public Cliente? Cliente { get; set; }
    }
    public class RespuestaTransaccionCliente
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public ClientesVM? Cliente { get; set; }
    }
    public class RespuestaValidacionCuenta
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public Cuenta? Cuenta { get; set; }
    }
    public class RespuestaTransaccionCuenta
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public CuentasVM? Cuenta { get; set; }
    }
    public class RespuestaValidacionMovimientos
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public Movimiento? Movimiento { get; set; }
    }
    public class RespuestaTransaccionMovimiento
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public MovimientosVM? Movimiento { get; set; }
    }
}
