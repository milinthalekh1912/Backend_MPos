using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginWithLine.Command.LoginWithLine;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginWithLineController : ApiControllerBase
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

        /// <summary>
        /// Login challenge
        /// </summary>
        /// <remarks>(Ready)</remarks>
        /// <response code="200">Login success</response>
        /// <response code="500">
        /// Login failed&lt;br&gt;
        /// SE001 = Username not found.&lt;br&gt;
        /// SE002 = Password not match.&lt;br&gt;
        /// </response>
        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "Login with Line OA", Description = "")]
        [ProducesResponseType(typeof(LoginWithLineResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> LoginWithLine([FromBody] LoginWithLineRequest request)
        {
            var cmd = new LoginWithLineCommand();
            cmd.LoginID = request.UserID;
            cmd.ConfigJWTValidIssuer = _config["JWT:ValidIssuer"];
            cmd.ConfigJWTValidAudience = _config["JWT:ValidAudience"];
            cmd.ConfigJWTSecret = _config["JWT:Secret"];

            var res = await _mediator.Send(cmd);
            return Ok(res);
        }

    }
}
