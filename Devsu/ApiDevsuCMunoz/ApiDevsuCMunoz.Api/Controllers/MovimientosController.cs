using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.CreateMovimiento;
using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.DeleteMovimiento;
using ApiDevsuCMunoz.Application.Features.Movimientos.Commands.UpdateMovimiento;
using ApiDevsuCMunoz.Application.Features.Movimientos.Queries.GetMovimientosList;
using ApiDevsuCMunoz.Application.Features.Movimientos.VModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiDevsuCMunoz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{CuentaNumero}", Name = "GetMovimiento")]
        [ProducesResponseType(typeof(IEnumerable<MovimientosVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MovimientosVM>>> GetMovimientosID(long CuentaNumero)
        {
            try
            { 
                var query = new GetMovimientosListQuery(CuentaNumero);
                var movimientos = await _mediator.Send(query);
                return Ok(movimientos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

        [HttpPost(Name = "CreateMovimiento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCuenta([FromBody] CreateMovimientoCommand command)
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

        [HttpPut(Name = "UpdateMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateMovimiento([FromBody] UpdateMovimientoCommand command)
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

        [HttpDelete("{numero}", Name = "DeleteMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMovimiento(long id)
        {
            try 
            { 
                var command = new DeleteMovimientoCommand()
                {
                    Id = id
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