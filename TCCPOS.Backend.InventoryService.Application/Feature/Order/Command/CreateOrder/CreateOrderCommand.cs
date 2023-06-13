using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public string user_id { get; set; }
        public string shop_id { get; set; }
        public string supplier_id { get; set; }
        public string? coupon_id { get; set; } = null!;
        [Required]
        public string address_id { get; set; }
        public List<OrderItemRequest> order_items { get; set; }

    }
}
