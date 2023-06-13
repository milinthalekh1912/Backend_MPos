using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.DeleteTarget
{
    public class DeleteTargetRequest
    {
        [Required]
        public string shopGroupId { get; set; }
        [Required]
        public string skuId { get; set; }

    }
}
