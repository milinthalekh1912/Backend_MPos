using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TCCPOS.Backend.InventoryService.Application.Feature;
using TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop;

namespace TCCPOS.Backend.InventoryService.WebApi.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MerchantController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MerchantController> _logger;

        public MerchantController(ILogger<MerchantController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        //ดึงข้อมูลร้านค้าทั้งหมดที่มีในระบบ รวมถึงที่อยู่
        [HttpGet("GetAllShopWithAddress")]
        [ProducesResponseType(typeof(GetAllMerchantAddressResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetShopData()
        {
            var query = new GetllAllMerchantAddressQuery();
            var res = await _mediator.Send(query);
            return Ok(res);
        }


        [Authorize]
        [HttpGet("getAllShop")]
        [SwaggerOperation(Summary = "", Description = "")]
        [ProducesResponseType(typeof(List<GetAllShopResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FailedResult), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> getAllShop()
        {
            var res = await _mediator.Send(new GetAllShopQuery());
            return Ok(res);
        }


    }
}
