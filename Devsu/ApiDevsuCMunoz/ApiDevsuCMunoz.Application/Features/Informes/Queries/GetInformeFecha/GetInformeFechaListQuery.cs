using ApiDevsuCMunoz.Application.Features.Informes.VModels;
using MediatR;
using System.Globalization;
using System.Web;

namespace ApiDevsuCMunoz.Application.Features.Informes.Queries.GetInformeFecha
{
    public class GetInformeFechaListQuery : IRequest<InformeCuentaVM>
    {
        public long _ClienteID { get; set; }
        public DateTime _FechaInicio { get; set; }
        public DateTime _FechaFin { get; set; }

        public GetInformeFechaListQuery(long clienteID, string fechaInicio, string fechaFin)
        {
            string fechaInicioDecodificada = HttpUtility.UrlDecode(fechaInicio);
            string fechaFinDecodificada = HttpUtility.UrlDecode(fechaFin);

            _ClienteID = clienteID;
            _FechaInicio = DateTime.ParseExact(fechaInicioDecodificada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _FechaFin = DateTime.ParseExact(fechaFinDecodificada, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
        }
    }
}