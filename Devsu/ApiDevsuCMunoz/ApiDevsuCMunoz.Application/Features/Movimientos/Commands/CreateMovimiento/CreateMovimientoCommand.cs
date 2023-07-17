using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientoCommand : IRequest<long>
    {
        public string Tipo { get; set; } = string.Empty;
        public double Valor { get; set; }
        public double Saldo { get; set; }
        public long? CuentaNumero { get; set; }
    }
}
