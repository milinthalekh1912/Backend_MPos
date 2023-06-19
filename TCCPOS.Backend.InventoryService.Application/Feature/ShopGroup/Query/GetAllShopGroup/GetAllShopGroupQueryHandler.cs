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
    public class GetAllShopGroupQueryHandler : IRequestHandler<GetAllShopGroupQuery, List<GetAllShopGroupResult>>
    {
        private readonly ILogger<GetAllShopGroupQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllShopGroupQueryHandler(ILogger<GetAllShopGroupQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<List<GetAllShopGroupResult>> Handle(GetAllShopGroupQuery request, CancellationToken cancellationToken)
        {
            //validate role before get shop group
            var shopGroup = await _repo.ShopGroup.getAllShopGroupAsync();
            return shopGroup;
        }
    }
}
