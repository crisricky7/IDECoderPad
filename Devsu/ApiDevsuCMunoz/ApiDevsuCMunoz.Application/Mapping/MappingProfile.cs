using ApiDevsuCMunoz.Application.Features.Clientes.Commands;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.CreateCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
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
            CreateMap<Cuenta, CuentasVM>();
            CreateMap<CreateCuentasCommand, Cuenta>();
            CreateMap<Movimiento, MovimientosVM>();
            CreateMap<CreateMovimientoCommand, Cuenta>();
        }
    }
}
