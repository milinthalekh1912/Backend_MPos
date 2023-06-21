namespace TCCPOS.Backend.InventoryService.Application.Feature.Order.Query.GetAllOrderByMerchantId
{
    public class GetAllOrderByMerchantIdResult
    {
        public List<GetAllOrderByMerchantIdItemResult> item { get; set; } = new List<GetAllOrderByMerchantIdItemResult>();
    }
}
