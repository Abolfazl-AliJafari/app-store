using app_store.Api.Models.Dtos.FileStorages;
using app_store.Common.Commands.FileStorages;
using app_store.Common.Queries.FileStorages.GetFileStorageAll;
using app_store.Common.Queries.FileStorages.GetFileStorageById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FileStorageController : BaseController
    {
        // GET: api/<FileStorageController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetFileStorageAllQuery();
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }


        // GET api/<FileStorageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetFileStorageByIdQuery(id);
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // POST api/<FileStorageController>
        [HttpPost("[action]")]

        public async Task<IActionResult> Post([FromForm] AddFileStorageDto fileStorage, CancellationToken cancellationToken)
        {
            if (fileStorage.File == null || fileStorage.File.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }
            using (var stream = new MemoryStream())
            {
                await fileStorage.File.CopyToAsync(stream);
                stream.Position = 0;
                var command = new CreateFileStorageCommand(
                    fileStorage.FilesName,
                    fileStorage.ContentsType,
                    fileStorage.FileSize,
                    fileStorage.Providers,
                    stream
                    );
                var result = await MediatorSender.Send(command, cancellationToken);
                if (result.IsSuccess)
                {
                    string? url = Url.Action(nameof(Get),
                            "FileStorage",
                            new { Id = result.Data },
                            Request.Scheme);
                    return Created(url, result.IsSuccess);
                }
                return BadRequest(result.Message);
            }
        }

        // PUT api/<FileStorageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateFileStorageDto fileStorage, CancellationToken cancellationToken)
        {
            var command = new UpdateFileStorageCommand(
                id,
                fileStorage.FileName,
                fileStorage.ContentType,
                fileStorage.FileSize,
                fileStorage.Providers
                );
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.Message);
        }

        // DELETE api/<FileStorageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new RemoveFileStorageCommand(id);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
