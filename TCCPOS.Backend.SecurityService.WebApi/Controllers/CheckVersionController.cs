using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.CheckVersion.Query.GetCheckVersion;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CheckVersionController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CheckVersionController> _logger;

        public CheckVersionController(ILogger<CheckVersionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetCheckVersion")]
        [ProducesResponseType(typeof(CheckVersionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetCheckVersionQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
