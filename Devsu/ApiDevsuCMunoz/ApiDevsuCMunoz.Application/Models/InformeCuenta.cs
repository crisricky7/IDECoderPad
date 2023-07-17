using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;

namespace ApiDevsuCMunoz.Application.Models
{
    public class InformeCuenta
    {
        public string Fecha { get; set; } = new DateTime().ToString("dd/MM/yyyy");
        public string? Cliente { get; set; }
        public IEnumerable<DetalleCuentaVM>? Cuentas { get; set; }
    }
}
