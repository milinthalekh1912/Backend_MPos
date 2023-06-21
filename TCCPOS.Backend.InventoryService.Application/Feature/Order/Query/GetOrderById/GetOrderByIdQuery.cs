using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdResult>
    {
        public string OrderId { get; set; }

        public string MerchantId { get; set; }

        public GetOrderByIdQuery(string merchantId,string orderId)
        {
            OrderId = orderId;
            MerchantId = merchantId;
        }
    }
}
