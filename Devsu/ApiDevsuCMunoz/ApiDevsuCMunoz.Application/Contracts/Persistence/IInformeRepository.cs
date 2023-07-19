using ApiDevsuCMunoz.Application.Features.Informes.VModels;

namespace ApiDevsuCMunoz.Application.Contracts.Persistence
{
    public interface IInformeRepository
    {
        Task<InformeCuentaVM> GeneraInformeCliente(long clienteID, DateTime fechaInicio, DateTime fechaFin);

    }
}
