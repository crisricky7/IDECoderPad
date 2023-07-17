﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.VModels
{
    public class DetalleMovimientosVM
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public double Valor { get; set; }
        public double Saldo { get; set; }
    }
}