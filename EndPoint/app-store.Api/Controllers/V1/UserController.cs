using app_store.Api.Models.Dtos.Users;
using app_store.Common.Commands.Users;
using app_store.Common.Queries.Users.GetUserAll;
using app_store.Common.Queries.Users.GetUserById;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var query = new GetUserAllQuery();
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery(id);
            var result = await MediatorSender.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return NotFound(result.Message);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserDto user,CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Password,
                user.Email);
            var result = await MediatorSender.Send(command,cancellationToken);
            if (result.IsSuccess)
            {

                string? url = Url.Action(nameof(Get),
                        "User",
                        new { Id = result.Data },
                        Request.Scheme);

                return Created(url, result.IsSuccess);
            }
            return BadRequest(result.Message);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserDto value,CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(
                id,
                value.FirstName,
                value.LastName,
                value.UserName,
                value.Password,
                value.Email);

            var result = await MediatorSender.Send(command,cancellationToken);
            if(result.IsSuccess)
            {
                return Ok();
            }
            return NotFound(result.Message);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken)
        {
            var command = new RemoveUserCommand(id);
            var result = await MediatorSender.Send(command,cancellationToken);
            if(result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Message);
        }
    }
}
