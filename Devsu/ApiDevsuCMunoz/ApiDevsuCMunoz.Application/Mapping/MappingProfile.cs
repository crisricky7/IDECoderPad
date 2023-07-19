using ApiDevsuCMunoz.Application.Features.Clientes.Commands;
using ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.CreateCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.UpdateCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento;
using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.UpdateMovimiento;
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
            CreateMap<ClientesVM,Cliente>();
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<Cliente, CreateClienteCommand>();
            CreateMap<UpdateClienteCommand, Cliente>();
            CreateMap<Cliente, UpdateClienteCommand>();
            
            CreateMap<Cuenta, CuentasVM>();
            CreateMap<CuentasVM, Cuenta>();
            CreateMap<CreateCuentasCommand, Cuenta>();
            CreateMap<Cuenta,CreateCuentasCommand> ();
            CreateMap<UpdateCuentasCommand, Cuenta>();
            CreateMap<Cuenta, UpdateCuentasCommand>();

            CreateMap<Movimiento, MovimientosVM>();
            CreateMap<MovimientosVM,Movimiento>();
            CreateMap<CreateMovimientoCommand, Movimiento>();
            CreateMap<Movimiento, CreateMovimientoCommand>();
            CreateMap<UpdateMovimientoCommand, MovimientosVM>();
            CreateMap<MovimientosVM, UpdateMovimientoCommand>();

            CreateMap<DetalleCuentaVM, Cuenta>();
            CreateMap<Cuenta, DetalleCuentaVM>();
            CreateMap<DetalleMovimientosVM,Movimiento>();
            CreateMap<Movimiento, DetalleMovimientosVM>();
        }
    }
}
