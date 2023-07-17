﻿using ApiDevsuCMunoz.Domain.Common;

namespace ApiDevsuCMunoz.Domain
{
    public class Movimiento : BaseDomainModel{
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
        public long? CuentaNumero { get; set; }
        public virtual Cuenta? Cuenta { get; set; }

    }
}
