using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.Logout.Command.Logout;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LogoutController : ApiControllerBase
    {
        private readonly ILogger<LogoutController> _logger;
        private readonly IMediator _mediator;
        IConfiguration _config;

        public LogoutController(ILogger<LogoutController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LogoutResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Post([FromBody] LogoutRequest request)
        {
            var cmd = new LogoutCommand(Identity.GetUsername(), Identity.GetPOSClientID());
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }

    }
}
