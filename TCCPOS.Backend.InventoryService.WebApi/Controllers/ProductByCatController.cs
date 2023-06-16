using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Principal;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.ProductByCat.Query.GetProductByCat;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductByCat : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductByCat> _logger;
        public ProductByCat(ILogger<ProductByCat> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "getProductByCat")]
        [ProducesResponseType(typeof(GetProductByCatResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(String supplierId, String categoryId)
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
    }
}
