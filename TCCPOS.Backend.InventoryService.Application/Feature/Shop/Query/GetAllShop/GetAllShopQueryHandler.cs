using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Shop.Query.GetAllShop
{
    public class GetAllShopQueryHandler : IRequestHandler<GetllAllShopAddressQuery, GetAllShopAddressResult>
    {
        private readonly ILogger<GetAllShopQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetAllShopQueryHandler(ILogger<GetAllShopQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetAllShopAddressResult> Handle(GetllAllShopAddressQuery request, CancellationToken cancellationToken)
        {
            var shopWithAddress = await _repo.getAllShopWithAddressAsync();

            return shopWithAddress;
        }
    }
}
