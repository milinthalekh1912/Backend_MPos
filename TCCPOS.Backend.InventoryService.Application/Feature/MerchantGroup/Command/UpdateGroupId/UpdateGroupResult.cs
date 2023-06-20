using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId
{
    public class UpdateGroupResult
    {
        public shopgroup shopgroup { get; set; }

        public List<shop> shops { get; set; }
    }
}
