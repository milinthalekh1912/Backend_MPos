using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;


namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
    {
        [Authorize]
        [ApiController]
        [Route("api/v1/[controller]")]
        public class ProductByKeywordController : ApiControllerBase
        {
            private readonly IMediator _mediator;
            private readonly ILogger<ProductByKeywordController> _logger;

            public ProductByKeywordController(ILogger<ProductByKeywordController> logger, IMediator mediator)
            {
                _logger = logger;
                _mediator = mediator;
            }

            [HttpGet("{keyword}", Name = "GetProductByKeyword")]
            [ProducesResponseType(typeof(List<ProductByKeywordResult>), (int)HttpStatusCode.OK)]
            [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
            [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
            public async Task<IActionResult> Get(string keyword)
            {
                var query = new GetProductByKeywordQuery (keyword);
                var res = await _mediator.Send(query);
                return Ok(res);
            }
        }
    }

}
