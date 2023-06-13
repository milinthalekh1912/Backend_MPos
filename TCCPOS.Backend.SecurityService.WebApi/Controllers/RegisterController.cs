using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Security.Claims;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.CreateUser.Command.CreateUser;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RegisterController> _logger;
        IConfiguration _config;

        public RegisterController(ILogger<RegisterController> logger, IMediator mediator, IConfiguration config)
        {
            _logger = logger;
            _mediator = mediator;
            _config = config;
        }


        [HttpPost]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(RegisterCommand), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RegisterRequest request)
        {
            var cmd = new RegisterCommand();
            cmd.Username = request.Username;
            cmd.Password = request.Password;
            var res = await _mediator.Send(cmd);
            
            return Ok(res);
        }
    }
}
