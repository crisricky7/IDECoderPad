using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using ApiDevsuCMunoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevsuCMunoz.Application.Models
{
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
