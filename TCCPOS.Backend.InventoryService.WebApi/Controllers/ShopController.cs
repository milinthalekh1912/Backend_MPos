using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Shop.Query.GetAllShop;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ShopController> _logger;

        public ShopController(ILogger<ShopController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetAllShopWithAddress")]
        [ProducesResponseType(typeof(GetAllShopAddressResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]

        public async Task<IActionResult> GetShopData()
        {
            var query = new GetllAllShopAddressQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
