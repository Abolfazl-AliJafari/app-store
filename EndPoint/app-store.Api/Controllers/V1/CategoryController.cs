using app_store.Api.Models.Dtos.Categories;
using app_store.Common.Commands.Categories;
using app_store.Common.Queries.Categories;
using app_store.Common.Queries.Categories.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetCategoryAllQuery();
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCategoryDto category, CancellationToken cancellationToken)
        {
            var command = new CreateCategoryCommand(
                category.Title,
                category.MainCategory);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                string? url = Url.Action(nameof(Get),
                        "Category",
                        new { Id = result.Data },
                        Request.Scheme);
                return Created(url, result.IsSuccess);
            }
            return BadRequest(result.Message);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCategoryDto value,CancellationToken cancellationToken)
        {
            var command = new UpdateCategoryCommand(
                id,
                value.Title,
                value.MainCategoryId);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.Message);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var command = new RemoveCategoryCommand(id);
            var result = await MediatorSender.Send(command, cancellationToken);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
