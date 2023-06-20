using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId
{
    public class UpdateGroupIdCommand : IRequest<UpdateMerchantGroupResult>
    {
        public string shopGroupId { get; set; }

        public string userId { get; set; }

        public string shopGroupName { get; set; }

        public List<string> shopList { get; set; }
    }
}
