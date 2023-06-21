using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;
using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotionLineOA;

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

        [HttpGet]
        [ProducesResponseType(typeof(List<PromotionResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> Get()
        {
            var query = new GetPromotionQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet("LineOA/")]
        [SwaggerOperation(Summary = "Get Promotion สำหรับ Line OA", Description = "")]
        [ProducesResponseType(typeof(GetPromotionLineOAResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetPromotionLineOA()
        {
            var query = new GetPromotionLineOAQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
