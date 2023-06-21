using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId
{
    public class UpdateMerchantGroupResult
    {
        public merchantgroup shopgroup { get; set; }

        public List<merchant> shops { get; set; }
    }
}
