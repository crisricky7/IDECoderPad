using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Cuentas.Commands.UpdateCuentas
{
    public class UpdateCuentasCommand : IRequest<Unit>
    {
        public long Numero { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public double? SaldoInicial { get; set; }
        public long? ClienteId { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
