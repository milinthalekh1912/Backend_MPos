using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId
{
    public class UpdateGroupRequest
    {
        [Required]
        public string shopGroupId { get; set; }

        [Required]
        public string shopGroupName { get; set; }

        [Required]
        public List<string> shopList { get; set; }
    }
}
