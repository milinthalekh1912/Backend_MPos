using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.CreateOrderBackOffice
{
    public class CreateOrderBackofficeItemRequest
    {
        [Required]
        public string sku_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public double price { get; set; }

    }
}
