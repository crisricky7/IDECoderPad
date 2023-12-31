﻿using ApiDevsuCMunoz.Application.Models;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommand : IRequest<RespuestaTransaccionMovimiento>
    {
        public long Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long? CuentaNumero { get; set; }
    }
}
