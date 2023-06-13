using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ConfirmLogistic.Command.ConfirmLogistic
{
    public class ConfirmLogisticRequest
    {
        [Required]
        public string order_id { get; set; }
        [Required]
        public string delivery_detail_id { get; set; }
        [Required]
        public string address_id { get; set;}
    }
}
