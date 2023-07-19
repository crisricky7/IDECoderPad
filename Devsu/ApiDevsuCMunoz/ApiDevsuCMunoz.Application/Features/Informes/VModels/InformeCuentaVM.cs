using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;

namespace ApiDevsuCMunoz.Application.Features.Informes.VModels
{
    public class InformeCuentaVM
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public ICollection<DetalleCuentaVM> Cuentas { get; set; } = new List<DetalleCuentaVM>();

    }
}
