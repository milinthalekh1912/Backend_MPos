using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop
{
    public class GetAllMerchantQueryHandler : IRequestHandler<GetllAllMerchantAddressQuery, GetAllMerchantAddressResult>
    {
        private readonly ILogger<GetAllMerchantQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetAllMerchantQueryHandler(ILogger<GetAllMerchantQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetAllMerchantAddressResult> Handle(GetllAllMerchantAddressQuery request, CancellationToken cancellationToken)
        {
            var shopWithAddress = await _repo.Merchant.getAllShopWithAddressAsync();
            return shopWithAddress;
        }
    }
}
