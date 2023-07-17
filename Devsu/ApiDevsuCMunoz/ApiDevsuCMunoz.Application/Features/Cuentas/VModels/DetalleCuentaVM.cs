using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.VModels
{
    public class DetalleCuentaVM
    {
        public string NumCuenta { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public double Saldo { get; set; }
        public IEnumerable<DetalleMovimientosVM>? Movimientos { get; set; }
        

    }
}
