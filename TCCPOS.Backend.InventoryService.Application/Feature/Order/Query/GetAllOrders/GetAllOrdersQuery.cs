using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<List<GetAllOrdersResult>>
    {
        public string userId { get; set; }
        public string shopId { get; set; }
        public string supplierId { get; set; }
    }
}
