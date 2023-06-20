using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Command.CreateShopGroup;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetAllShopGroup
{
    public class GetAllMerchantGroupQuery : IRequest<List<GetAllMerchantGroupResult>>
    {

    }
}
