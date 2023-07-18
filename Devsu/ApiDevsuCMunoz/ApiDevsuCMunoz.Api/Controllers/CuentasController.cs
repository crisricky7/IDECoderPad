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
        [HttpGet("{numero}", Name = "GetNumCuentas")]
        [ProducesResponseType(typeof(IEnumerable<CuentasVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CuentasVM>>> GetCuentasCuentaID(long numero)
        {
            try
            {
                var query = new GetCuentasListQuery(numero);//falta
                var cuentas = await _mediator.Send(query);
                return Ok(cuentas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

        // POST api/<CuentaController>
        [HttpPost(Name = "CreateCuenta")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCuenta([FromBody] CreateCuentasCommand command)
        {
            try 
            {
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut(Name = "UpdateCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateCuenta([FromBody] UpdateCuentasCommand command)
        {
            try
            {    
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{numero}", Name = "DeleteCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCuenta(long numero)
        {
            try
            {
                var command = new DeleteCuentasCommand()
                {
                    Numero = numero
                };

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }

        }
    }
}
