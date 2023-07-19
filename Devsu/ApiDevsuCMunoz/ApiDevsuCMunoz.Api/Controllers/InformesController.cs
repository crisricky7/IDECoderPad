using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
