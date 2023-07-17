

using ApiDevsuCMunoz.Domain;

namespace ApiDevsuCMunoz.Application.Features.Clientes.VModels
{
    public class ClientesVM : Persona
    {
        public long Id { get; set; }
        public string? Contrasenia { get; set; }
        public string? Estado { get; set; }
    }
}
