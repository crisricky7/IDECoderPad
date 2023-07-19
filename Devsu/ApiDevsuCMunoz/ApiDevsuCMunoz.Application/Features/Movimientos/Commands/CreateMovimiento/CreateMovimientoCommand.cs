using ApiDevsuCMunoz.Application.Models;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientoCommand : IRequest<RespuestaTransaccionMovimiento>
    {
        public string Tipo { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public long? CuentaNumero { get; set; }
    }
}
