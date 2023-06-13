using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup
{
    public class CreateShopGroupRequest
    {
        [Required]
        public string shopGroupName { get; set; } = null;

        [Required]
        public List<string> shopId { get; set; }
    }
}
