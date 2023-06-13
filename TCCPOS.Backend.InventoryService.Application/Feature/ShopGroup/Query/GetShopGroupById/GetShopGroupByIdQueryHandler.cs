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
    public class GetShopGroupByIdQueryHandler : IRequestHandler<GetShopGroupByIdQuery, GetShopGroupByIdResult>
    {
        private readonly ILogger<GetShopGroupByIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetShopGroupByIdQueryHandler(ILogger<GetShopGroupByIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetShopGroupByIdResult> Handle(GetShopGroupByIdQuery request, CancellationToken cancellationToken)
        {
            //validate role before get shop group
            var shopGroup = await _repo.getShopGroupById(request.shopGroupId);
            return shopGroup;
        }
    }
}
