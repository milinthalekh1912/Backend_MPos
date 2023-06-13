using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShop
{
    public class GetAllShopQueryHandler : IRequestHandler<GetAllShopQuery, List<GetAllShopResult>>
    {
        private readonly ILogger<GetAllShopQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllShopQueryHandler(ILogger<GetAllShopQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<List<GetAllShopResult>> Handle(GetAllShopQuery request, CancellationToken cancellationToken)
        {
            //validate role before get shop group
            var shops = await _repo.getAllShopAsync();
            return shops;
        }
    }
}
