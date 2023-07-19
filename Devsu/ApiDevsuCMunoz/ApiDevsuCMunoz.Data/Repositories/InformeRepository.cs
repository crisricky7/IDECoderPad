using ApiDevsuCMunoz.Application.Contracts.Persistence;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using ApiDevsuCMunoz.Application.Features.Informes.VModels;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using ApiDevsuCMunoz.Infrestructure.Persistence;
using AutoMapper;

namespace ApiDevsuCMunoz.Infrastructure.Repositories
{
    public class InformeRepository : IInformeRepository
    {
        public ApiDevsuCMunozDbContext _context;

        private readonly IMapper _mapper;
        public InformeRepository(ApiDevsuCMunozDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InformeCuentaVM> GeneraInformeCliente(long clienteID, DateTime fechaInicio, DateTime fechaFin)
        {
            InformeCuentaVM informeCuentaVM = new InformeCuentaVM();
            DetalleCuentaVM detalleCuentaVM = new DetalleCuentaVM();
            
            var datoscliente = _context!.Clientes!.Where(x => x.Id == clienteID).FirstOrDefault();

            informeCuentaVM.Fecha = DateTime.Now;
            informeCuentaVM.Cliente = datoscliente.Nombre;

            var cuentas = _context!.Cuentas!.Where(x => x.ClienteId == clienteID && x.Estado.Equals("True")).ToList();
            
            foreach (var cuenta in cuentas) {
                var cuentaVM = _mapper.Map<DetalleCuentaVM>(cuenta);
                
                var movimientos = _context!.Movimientos!.Where(x => x.CuentaNumero == cuentaVM.Numero &&
                          (x.Fecha.Value.Year >= fechaInicio.Year || x.Fecha.Value.Year <= fechaFin.Year) &&
                          (x.Fecha.Value.Month >= fechaInicio.Month || x.Fecha.Value.Day <= fechaFin.Month) &&
                          (x.Fecha.Value.Day >= fechaInicio.Day || x.Fecha.Value.Month <= fechaFin.Day)).ToList();
                
                foreach (var movimiento in movimientos) {
                    var detalleMovimientoVM = _mapper.Map<DetalleMovimientosVM>(movimiento);
                    cuentaVM.Movimientos.Add(detalleMovimientoVM);
                }
                try
                {
                    informeCuentaVM.Cuentas.Add(cuentaVM);

                }
                catch (Exception ex){ 
                    ex.ToString();
                }
            }

            return await Task.FromResult(informeCuentaVM); 
        }

    }
}
