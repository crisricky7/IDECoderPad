using ApiDevsuCMunoz.Domain.Common;

namespace ApiDevsuCMunoz.Domain
{
    public class Movimiento : BaseDomainModel{
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long? CuentaNumero { get; set; }
        public DateTime? Fecha { get; set; }=DateTime.Now;
        public virtual Cuenta? Cuenta { get; set; }

    }
}
