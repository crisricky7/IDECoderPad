using ApiDevsuCMunoz.Application.Models;
using MediatR;

namespace ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<RespuestaTransaccionCliente>
    {
        public long Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
