using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup
{
    public class DeleteShopGroupRequest
    {
        [Required]
        public string shopGroupId { get; set; }
    }
}
