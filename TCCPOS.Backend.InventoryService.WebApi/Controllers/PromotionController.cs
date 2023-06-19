using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
   [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromotionController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PromotionController> _logger;

        public PromotionController(ILogger<PromotionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPromotion")]
        [ProducesResponseType(typeof(List<PromotionResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> Get()
        {
            var query = new GetPromotionQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
