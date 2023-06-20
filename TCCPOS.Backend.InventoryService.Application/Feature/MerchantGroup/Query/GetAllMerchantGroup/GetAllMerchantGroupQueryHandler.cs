using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup
{
    public class GetAllMerchantGroupQueryHandler : IRequestHandler<GetAllMerchantGroupQuery, List<GetAllMerchantGroupResult>>
    {
        private readonly ILogger<GetAllMerchantGroupQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllMerchantGroupQueryHandler(ILogger<GetAllMerchantGroupQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<List<GetAllMerchantGroupResult>> Handle(GetAllMerchantGroupQuery request, CancellationToken cancellationToken)
        {
            //validate role before get shop group
            var shopGroup = await _repo.MerchantGroup.getAllShopGroupAsync();
            return shopGroup;
        }
    }
}
