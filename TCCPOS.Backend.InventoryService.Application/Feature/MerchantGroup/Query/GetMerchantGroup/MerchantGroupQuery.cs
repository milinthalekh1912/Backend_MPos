using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup
{
    public class GetMerchantGroupByGroupIDQuery : IRequest<List<MerchantGroupResult>>
    {
        public string keyword { get; set; }

        public GetMerchantGroupByGroupIDQuery(string keyword)

        {
            this.keyword = keyword;
        }

    }
}


