using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend;
using TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SkuController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SkuController> _logger;

        public SkuController(ILogger<SkuController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet("{supplierId}/{categoryId}")]
        [ProducesResponseType(typeof(GetProductByCatResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetSkuByCategory(String supplierId, String categoryId)
        {
            var query = new GetProductByCatQuery
            {
                supplierId = supplierId,
                categoryId = categoryId,
                shopId = Identity.GetShopID(),
            };
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet("Search/{keyword}")]
        [ProducesResponseType(typeof(List<SkuByKeywordResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetSkuByKeyword(string keyword)
        {
            var query = new GetSkuByKeywordQuery(keyword);
            var res = await _mediator.Send(query);
            return Ok(res);
        }


        [HttpGet("Recommended/{supplier_id}")]
        [ProducesResponseType(typeof(List<SkuRecommendResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetRecommendedSku(string supplier_id)
        {
            var query = new GetSkuRecommendQuery(supplier_id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        
        [HttpGet]
        [Route("{supplierId}/{categoryId}")]
        [SwaggerOperation(Summary = "Get SKU List For Line OA", Description = "")]
        [ProducesResponseType(typeof(GetSkuListResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetSkuForLineOA(string supplierId,string categoryId)
        {
            var query = new GetSkuListByCategoryIdQuery(supplierId,categoryId);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
