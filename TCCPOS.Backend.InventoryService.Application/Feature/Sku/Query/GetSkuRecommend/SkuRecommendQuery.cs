
using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend
{
    public class GetSkuRecommendQuery : IRequest<List<SkuRecommendResult>>
    {
        public string Supplier_id { get; set; }
        public string Merchant_id { get; set; }

        public GetSkuRecommendQuery(string supplierId, string merchant_id)
        {
            Supplier_id = supplierId;
            Merchant_id = merchant_id;
        }
    }
}
