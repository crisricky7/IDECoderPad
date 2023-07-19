using ApiDevsuCMunoz.Domain.Common;

namespace ApiDevsuCMunoz.Domain
{
    public class Cliente : Persona { 
        public long Id { get; set; }
        public string? Contrasenia { get; set; }
        public string? Estado { get; set; }
        public virtual ICollection<Cuenta>? Cuentas { get; set; }
    }
}
