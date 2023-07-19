using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.VModels
{
    public class DetalleCuentaVM
    {
        public long Numero { get; set; }
        public string? Tipo { get; set; } = string.Empty;
        public decimal? SaldoInicial { get; set; }
        public long? ClienteId { get; set; }
        public string? Estado { get; set; } = string.Empty;
        public ICollection<DetalleMovimientosVM>? Movimientos { get; set; } = new List<DetalleMovimientosVM>();
        

    }
}
