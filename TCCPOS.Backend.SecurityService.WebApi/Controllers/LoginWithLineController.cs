using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLogin;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginWithLineController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginWithLineController> _logger;
        IConfiguration _config;

        public LoginWithLineController(ILogger<LoginWithLineController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(LineLoginCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LineLoginRequest request)
        {
            var cmd = new LineLoginCommand();
            cmd.accessToken = request.accessToken;
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }
    }
}
