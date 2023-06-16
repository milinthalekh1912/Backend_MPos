using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.UpdateOrderStatus
{
    public class UpdateOrderStatusRequest
    {
        [Required]
        public string orderId { get; set; }
        /*[Required]
        public int order_status { get; set; }*/
    }
}