using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackOfficeRequest
    {
        [Required]
        public string supplier_id { get; set; }
        [Required]
        public string merchant_id { get; set; }
        public string? coupon_id { get; set; }

        [Required]
        public string address_id { get; set; }

        [Required]
        public List<CreateOrderBackofficeItemRequest> order_items { get; set; }

    }
}
