
using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductRecommend.Query.GetProductRecommend
{
    public class GetProductRecommendQuery : IRequest<List<ProductRecommendResult>>
    {
        public string supplier_id { get; set; }

        public GetProductRecommendQuery(string supplierId)
        {
            supplier_id = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
        }
    }
}
