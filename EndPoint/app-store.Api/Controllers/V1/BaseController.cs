using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace app_store.Api.Controllers.v1
{
    public class BaseController : ControllerBase
    {
        private ISender _mediatorSender = null!;
        protected ISender MediatorSender => _mediatorSender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
