using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.VModels
{
    public class CuentasVM
    {
        public long Numero { get; set; }
        public string? Tipo { get; set; } = string.Empty;
        public decimal? SaldoInicial { get; set; }
        public long? ClienteId { get; set; }
        public string? Estado { get; set; } = string.Empty;
    }
}
