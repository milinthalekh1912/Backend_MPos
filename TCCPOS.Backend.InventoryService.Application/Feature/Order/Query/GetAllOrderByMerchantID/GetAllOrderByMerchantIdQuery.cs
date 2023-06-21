using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId
{
    public class GetAllOrderByMerchantIdQuery : IRequest<GetAllOrderByMerchantIdResult>
    {
        public string MerchantId { get; set; }

        public GetAllOrderByMerchantIdQuery(string merchantId)
        {
            MerchantId = merchantId;
        }
    }
}
