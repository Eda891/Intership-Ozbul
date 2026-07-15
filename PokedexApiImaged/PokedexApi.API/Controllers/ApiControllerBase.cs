using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PokedexApi.API.Controllers
{
    //Base class all controllers inherit from; gives access to Mediator
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
