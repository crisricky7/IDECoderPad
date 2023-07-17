using ApiDevsuCMunoz.Application.Features.Clientes.Commands;
using ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente;
using ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente;
using ApiDevsuCMunoz.Application.Features.Clientes.Queries.GetClientesList;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiDevsuCMunoz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetClienteId")]
        [ProducesResponseType(typeof(IEnumerable<ClientesVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientesVM>>> GetClienteByIdentificacion(long id)
        {
            var query = new GetClientesListQuery(id);
            var cliente = await _mediator.Send(query);
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost(Name = "CreateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<long>> CreateCliente([FromBody] CreateClienteCommand command)
        {
            return await _mediator.Send(command);
        }

        // PUT api/<ClienteController>/5
        [HttpPut(Name ="UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<long>> UpdateCliente([FromBody] UpdateClienteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCliente(long id)
        {
            var command = new DeleteClienteCommand() { 
                Id = id
            };
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
