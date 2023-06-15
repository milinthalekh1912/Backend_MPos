using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;


using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductRecommend.Query.GetProductRecommend;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductRecommendController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductRecommendController> _logger;

        public ProductRecommendController(ILogger<ProductRecommendController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{supplier_id}", Name = "GetProductRecommend")]
        [ProducesResponseType(typeof(List<ProductRecommendResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Get(string supplier_id)
        {
            var query = new GetProductRecommendQuery(supplier_id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
