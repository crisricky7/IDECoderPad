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
        // GET: api/<InformesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InformesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InformesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InformesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InformesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
