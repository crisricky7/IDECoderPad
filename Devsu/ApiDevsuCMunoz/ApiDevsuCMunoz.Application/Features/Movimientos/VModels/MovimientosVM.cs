﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.VModels
{
    public class MovimientosVM
    {
        public long Id { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long? CuentaNumero { get; set; }
    }
}
