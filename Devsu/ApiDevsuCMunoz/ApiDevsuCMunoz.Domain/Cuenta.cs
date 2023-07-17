using System.ComponentModel.DataAnnotations;

namespace ApiDevsuCMunoz.Domain
{
    public class Cuenta
    {
        [Key]
        public long Numero { get; set; }
        public string? Tipo { get; set; }
        public double? SaldoInicial { get; set; }
        public long? ClienteId { get; set; }
        public string? Estado { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
