namespace ApiDevsuCMunoz.Application.Features.Movimientos.VModels
{
    public class DetalleMovimientosVM
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}
