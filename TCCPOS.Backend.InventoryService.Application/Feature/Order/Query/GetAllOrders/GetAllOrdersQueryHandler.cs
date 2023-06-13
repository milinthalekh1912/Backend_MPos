using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersResult>>
    {
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllOrdersQueryHandler(ILogger<GetAllOrdersQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<List<GetAllOrdersResult>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _repo.getAllOrderAsync(request.supplierId, request.userId, request.shopId);

            return allOrders;
        }
    }
}
