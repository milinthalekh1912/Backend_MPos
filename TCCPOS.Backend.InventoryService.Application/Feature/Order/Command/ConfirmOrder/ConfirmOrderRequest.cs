using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Command.ConfirmOrder
{
    public class ConfirmOrderRequest
    {
        [Required]
        public string orderId { get; set; }
        [Required]
        public string note { get; set; } = null;
        [Required]
        public DateTime esimate_date { get; set; }
        [Required]
        public DateTime due_date { get; set; }
        [Required]
        public bool is_boardcase { get; set; }
    }
}