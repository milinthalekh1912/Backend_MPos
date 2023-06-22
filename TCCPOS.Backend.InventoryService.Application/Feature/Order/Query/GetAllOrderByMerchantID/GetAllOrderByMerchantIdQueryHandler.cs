using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById
{
    public class GetAllOrderByMerchantIdQueryHandler : IRequestHandler<GetAllOrderByMerchantIdQuery, GetAllOrderByMerchantIdResult>
    {
        private readonly ILogger<GetAllOrderByMerchantIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAllOrderByMerchantIdQueryHandler(ILogger<GetAllOrderByMerchantIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetAllOrderByMerchantIdResult> Handle(GetAllOrderByMerchantIdQuery request, CancellationToken cancellationToken)
        {
            var res = new GetAllOrderByMerchantIdResult();
            res = await _repo.Order.getAllOrderByMerchantID(request.MerchantId);
            res.item = res.item.OrderBy(x => x.created_date).ToList();
            return res;
        }
    }
}

