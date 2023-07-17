using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.CreateCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.DeleteCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.Commands.UpdateCuentas;
using ApiDevsuCMunoz.Application.Features.Cuentas.Queries.GetCuentasList;
using ApiDevsuCMunoz.Application.Features.Cuentas.VModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiDevsuCMunoz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/<CuentaController>/5
        [HttpGet("{Numero}", Name = "GetNumCuentas")]
        [ProducesResponseType(typeof(IEnumerable<CuentasVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CuentasVM>>> GetCuentasCuentaID(long numero)
        {
            var query = new GetCuentasListQuery(numero);//falta
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }

        // POST api/<CuentaController>
        [HttpPost(Name = "CreateCuenta")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCuenta([FromBody] CreateCuentasCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<CuentaController>/5
        [HttpPut(Name = "UpdateCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateCuenta([FromBody] UpdateCuentasCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{numero}", Name = "DeleteCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCuenta(long numero)
        {
            var command = new DeleteCuentasCommand()
            {
                Numero = numero
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
