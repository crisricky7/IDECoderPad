using ApiDevsuCMunoz.Application.Features.Informes.Queries.GetInformeFecha;
using ApiDevsuCMunoz.Application.Features.Informes.VModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiDevsuCMunoz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InformesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{ClienteID}, {FechaInicio}, {FechaFin}", Name = "GeneraInformeCliente")]
        [ProducesResponseType(typeof(InformeCuentaVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<InformeCuentaVM>> GeneraInformeCliente(long ClienteID, string FechaInicio, string FechaFin)
        {
            try
            {
                var query = new GetInformeFechaListQuery(ClienteID, FechaInicio, FechaFin);
                var informe = await _mediator.Send(query);
                return Ok(informe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

    }
}
