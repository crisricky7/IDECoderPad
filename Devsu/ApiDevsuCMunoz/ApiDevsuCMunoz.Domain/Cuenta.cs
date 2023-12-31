﻿using ApiDevsuCMunoz.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ApiDevsuCMunoz.Domain
{
    public class Cuenta : BaseDomainModel{
        [Key]
        public long Numero { get; set; }
        public string? Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public long? ClienteId { get; set; }
        public string? Estado { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Movimiento>? Movimientos { get; set; }
    }
}
