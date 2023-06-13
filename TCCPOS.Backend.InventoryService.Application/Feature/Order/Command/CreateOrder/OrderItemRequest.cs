using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrder
{
    public class OrderItemRequest
    {
        [Required]
        public string sku_id { get; set; }
        [Required]
        public int amount { get; set; }

    }
}
