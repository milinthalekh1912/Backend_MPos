using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.Login;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginController> _logger;
        IConfiguration _config;

        public LoginController(ILogger<LoginController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(LoginQuery), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            var query = new LoginQuery();
            query.Username = request.Username;
            query.Password = request.Password;
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
