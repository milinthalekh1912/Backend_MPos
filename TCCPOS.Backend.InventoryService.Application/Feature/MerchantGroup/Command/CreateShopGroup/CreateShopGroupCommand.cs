using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup
{
    public class CreateShopGroupCommand : IRequest<CreateShopGroupResult>
    {
        public string shopGroupName { get; set; }
        public List<string> shopId { get; set; }

        public string userId { get; set; }
    }
}
