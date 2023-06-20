using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Merchant.Query.GetAllShop
{
    public class GetAllShopQuery : IRequest<List<GetAllShopResult>>
    {
    }
}
