using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById;
using TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressController> _logger;
        public AddressController(ILogger<AddressController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        //ดึงข้อมูลที่อยู่ของร้าน ShopId
        [Authorize]
        [HttpGet("Customer")]
        [SwaggerOperation(Summary = "Get all address of customer", Description = "")]
        [ProducesResponseType(typeof(List<AllAddressResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAllAddress()
        {
            var query = new GetAllAddressQuery
            {
                shopId = Identity.GetMerchantID(),
            };
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet("Detail/{id}")]
        [SwaggerOperation(Summary = "Get address detail by addressId", Description = "")]
        [ProducesResponseType(typeof(GetAddressByIdResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetAddressById(String id)
        {
            var query = new GetAddressByIdQuery(id);
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}
