using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.SecurityService.Application.Feature;
using TCCPOS.Backend.SecurityService.Application.Feature.GeneralInfo.Query.GetGeneralInfo;

namespace TCCPOS.Backend.SecurityService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GeneralInfoController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GeneralInfoController> _logger;

        public GeneralInfoController(ILogger<GeneralInfoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GeneralInfoResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Get()
        {
            var query = new GetGeneralInfoQuery("");
            var res = await _mediator.Send(query);
            return Ok(res);
        }

    }
}
