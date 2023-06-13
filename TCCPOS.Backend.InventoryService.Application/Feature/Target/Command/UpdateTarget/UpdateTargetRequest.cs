using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Command.UpdateTarget
{
    public class UpdateTargetRequest
    {
        [Required]
        public string targetId { get; set; }
        [Required]
        public string shopGroupId { get; set; }
        [Required]
        public string skuId { get; set; }
        [Required]
        public int target { get; set; }
        [Required]
        public string reward { get; set; }
        [Required]
        public string resetDate { get; set; }
    }
}
