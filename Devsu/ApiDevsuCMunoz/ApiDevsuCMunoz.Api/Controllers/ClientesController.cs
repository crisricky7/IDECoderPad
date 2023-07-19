using ApiDevsuCMunoz.Application.Features.Clientes.Commands;
using ApiDevsuCMunoz.Application.Features.Clientes.Commands.DeleteCliente;
using ApiDevsuCMunoz.Application.Features.Clientes.Commands.UpdateCliente;
using ApiDevsuCMunoz.Application.Features.Clientes.Queries.GetClientesList;
using ApiDevsuCMunoz.Application.Features.Clientes.VModels;
using ApiDevsuCMunoz.Application.Models;
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

        [HttpGet("{id}", Name = "GetClienteId")]
        [ProducesResponseType(typeof(IEnumerable<ClientesVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClientesVM>>> GetClienteById(long id)
        {
            try 
            {
                var query = new GetClientesListQuery(id);
                var cliente = await _mediator.Send(query);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }

        [HttpPost(Name = "CreateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<RespuestaTransaccionCliente>> CreateCliente([FromBody] CreateClienteCommand command)
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

        [HttpPut(Name ="UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RespuestaTransaccionCliente>> UpdateCliente([FromBody] UpdateClienteCommand command)
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

        [HttpDelete("{id}", Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RespuestaTransaccionCliente>> DeleteCliente(long id)
        {
            try
            { 
                var command = new DeleteClienteCommand() { 
                    Id = id
                };
                
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }
    }
}
