using app_store.Api.Models.Dtos.Apps;
using app_store.Common.Commands.Apps;
using app_store.Common.Queries.Apps.GetAppAll;
using app_store.Common.Queries.Apps.GetAppById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppController : BaseController
    {
        // GET: api/<AppController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetAppAllQuery();
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // GET api/<AppController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id,CancellationToken cancellationToken)
        {
            var query = new GetAppByIdQuery(id);
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // POST api/<AppController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAppDto app,CancellationToken cancellationToken)
        {
            var command = new CreateAppCommand(
                app.Title,
                app.Description,
                app.PhotosGallery,
                app.IconId,
                app.ProducerId,
                app.AppFileId,
                app.CategoryId);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                string? url = Url.Action(nameof(Get),
                        "App",
                        new { Id = result.Data },
                        Request.Scheme);
                return Created(url, result.IsSuccess);
            }
            return BadRequest(result.Message);
        }

        // PUT api/<AppController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAppDto app,CancellationToken cancellationToken)
        {
            var command = new UpdateAppCommand(
                id,
                app.Title,
                app.Description,
                app.PhotosGallery,
                app.IconId,
                app.ProducerId,
                app.AppFileId,
                app.CategoryId
                );
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.Message);
        }

        // DELETE api/<AppController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var command = new RemoveAppCommand(id);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
