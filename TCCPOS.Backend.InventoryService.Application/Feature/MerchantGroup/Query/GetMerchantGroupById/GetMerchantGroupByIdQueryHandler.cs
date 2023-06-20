using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById
{
    public class GetMerchantGroupByIdQueryHandler : IRequestHandler<GetMerchantGroupByIdQuery, GetMerchantGroupByIdResult>
    {
        private readonly ILogger<GetMerchantGroupByIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetMerchantGroupByIdQueryHandler(ILogger<GetMerchantGroupByIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetMerchantGroupByIdResult> Handle(GetMerchantGroupByIdQuery request, CancellationToken cancellationToken)
        {
            //validate role before get shop group
            var shopGroup = await _repo.MerchantGroup.getShopGroupById(request.shopGroupId);
            return shopGroup;
        }
    }
}
