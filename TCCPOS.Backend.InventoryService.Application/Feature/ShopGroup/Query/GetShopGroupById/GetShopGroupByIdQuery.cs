using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroupById
{
    public class GetShopGroupByIdQuery : IRequest<GetShopGroupByIdResult>
    {
        public string shopGroupId { get; set; }
    }
}
