using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuWithPriceTierByPriceTierID;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductByCat;
using TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend;
using TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class SkuController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SkuController> _logger;

        public SkuController(ILogger<SkuController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
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


        [HttpGet("Recommended/{supplierId}")]
        [ProducesResponseType(typeof(List<SkuRecommendResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetRecommendedSku(string supplier_id)
        {
            var query = new GetSkuRecommendQuery(supplier_id,Identity.GetMerchantID());
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("All/{supplierId}")]
        [ProducesResponseType(typeof(GetAllSkuResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllSkuBySupplierId(string supplier_id)
        {
            var query = new GetAllSkuBySupplierIdQuery(Identity.GetMerchantID(),supplier_id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("All/WithPriceTier/{supplierId}/{price_tier_id}")]
        [ProducesResponseType(typeof(GetAllSkuResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAllSkuWithPriceTierBySupplierId(string supplierId, string price_tier_id)
        {
            var query = new GetAllSkuWithPriceTierByPriceTierIDQuery(supplierId, price_tier_id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("{supplierId}/{categoryId}")]
        [SwaggerOperation(Summary = "Get SKU List By SupplierID And CategoriesID", Description = "")]
        [ProducesResponseType(typeof(GetSkuListResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetSkuForLineOA(string supplierId, string categoryId)
        {
            var query = new GetSkuListByCategoryIdQuery(Identity.GetMerchantID(), supplierId, categoryId);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
