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
using TCCPOS.Backend.SecurityService.Application.Feature.LoginUser.Query.LoginEmployee;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginEmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LoginEmployeeController> _logger;
        IConfiguration _config;

        public LoginEmployeeController(ILogger<LoginEmployeeController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(LoginEmployeeQuery), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            var query = new LoginEmployeeQuery();
            query.Username = request.Username;
            query.Password = request.Password;
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
