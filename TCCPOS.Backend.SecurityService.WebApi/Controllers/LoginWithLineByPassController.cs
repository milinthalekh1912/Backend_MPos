using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLogin;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginWith.Command.LineLoginByPass;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginWithLineByPassController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginWithLineByPassController> _logger;
        IConfiguration _config;

        public LoginWithLineByPassController(ILogger<LoginWithLineByPassController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(LineLoginByPassResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LineLoginByPassRequest request)
        {
            var cmd = new LineLoginByPassCommand(request);
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }
    }
}
