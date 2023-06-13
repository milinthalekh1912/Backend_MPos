using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.DeleteShopGroup
{
    public class DeleteShopGroupCommand : IRequest<DeleteShopGroupResult>
    {
        public string shopGroupId { get; set; }
        public string userId { get; set; }
    }
}
