using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupId;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.UpdateGroupName
{
    public class UpdateGroupNameCommand : IRequest<UpdateGroupNameResult>
    {
        public string shopGroupId { get; set; }

        public string shopGroupName { get; set; }

        public string userId { get; set; }
    }
}
