using app_store.Api.Models.Dtos.Auth;
using app_store.Common.Commands.Users;
using Microsoft.AspNetCore.Mvc;

namespace app_store.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command = new LoginCommand(
                loginDto.UserName,
                loginDto.Password);

            var result = await MediatorSender.Send(command);

            if (result.Data)
                return Ok(new { message = result.Message });
            else
                return Unauthorized(new { message = result.Message });
        }
    }
}
