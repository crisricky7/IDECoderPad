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
        // GET api/<CuentaController>/5
        [HttpGet("{Numero}", Name = "GetMovimiento")]
        [ProducesResponseType(typeof(IEnumerable<MovimientosVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MovimientosVM>>> GetMovimientosID(long id)
        {
            var query = new GetMovimientosListQuery(id);//falta
            var videos = await _mediator.Send(query);
            return Ok(videos);
        }

        // POST api/<CuentaController>
        [HttpPost(Name = "CreateMovimiento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCuenta([FromBody] CreateMovimientoCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<CuentaController>/5
        [HttpPut(Name = "UpdateMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateMovimiento([FromBody] UpdateMovimientoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<CuentaController>/5
        [HttpDelete("{numero}", Name = "DeleteMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMovimiento(long id)
        {
            var command = new DeleteMovimientoCommand()
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}