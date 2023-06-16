using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup
{
    public class GetShopGroupByGroupIDQuery : IRequest<List<ShopGroupResult>>
    {
        public string keyword { get; set; }

        public GetShopGroupByGroupIDQuery(string keyword)

        {
            this.keyword = keyword;
        }

    }
}


