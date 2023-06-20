
using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetProductRecommend
{
    public class GetSkuRecommendQuery : IRequest<List<SkuRecommendResult>>
    {
        public string supplier_id { get; set; }

        public GetSkuRecommendQuery(string supplierId)
        {
            supplier_id = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
        }
    }
}
