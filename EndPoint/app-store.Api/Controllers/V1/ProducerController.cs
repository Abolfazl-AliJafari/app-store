using app_store.Api.Models.Dtos.Producers;
using app_store.Common.Commands.Producers;
using app_store.Common.Queries.Producers.GetProductAll;
using app_store.Common.Queries.Producers.GetProductById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProducerController : BaseController
    {
        // GET: api/<ProducerController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetProducerAllQuery();
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetProducerByIdQuery(id);
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProducerDto producer, CancellationToken cancellationToken)
        {
            var command = new CreateProducerCommand(
                producer.Title,
                producer.Description,
                producer.Email);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                string? url = Url.Action(nameof(Get),
                        "Producer",
                        new { Id = result.Data },
                        Request.Scheme);
                return Created(url, result.IsSuccess);
            }
            return BadRequest(result.Message);
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProducerDto producer, CancellationToken cancellationToken)
        {
            var command = new UpdateProducerCommand(
                id,
                producer.Title,
                producer.Description
                );
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.Message);
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var command = new RemoveProducerCommand(id);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
