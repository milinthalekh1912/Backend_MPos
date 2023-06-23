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
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderBackOfficeById;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById
{
    public class GetOrderBackOfficeByIdQueryHandler : IRequestHandler<GetOrderBackOfficeByIdQuery, GetOrderByIdResult>
    {
        private readonly ILogger<GetOrderBackOfficeByIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetOrderBackOfficeByIdQueryHandler(ILogger<GetOrderBackOfficeByIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetOrderByIdResult> Handle(GetOrderBackOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repo.Order.getOrderByIdBackOfficeAsync(request.OrderId);

            if (orderDetail == null)
            {
                throw InventoryServiceException.IE013;
            }
            var deliverysDetail = await _repo.DeliveryDetail.getDeliveryDetailsByOrderIdAsync(request.OrderId);

            orderDetail.deliverydetails = deliverysDetail;

            return orderDetail;
        }
    }
}
