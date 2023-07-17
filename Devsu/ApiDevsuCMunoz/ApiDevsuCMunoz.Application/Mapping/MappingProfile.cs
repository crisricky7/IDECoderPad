using ApiDevsuCMunoz.Application.Features.Clientes.Commands;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Domain;
using AutoMapper;

namespace ApiDevsuCMunoz.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClientesVM>();
            CreateMap<CreateClienteCommand, Cliente>();
        }
    }
}
