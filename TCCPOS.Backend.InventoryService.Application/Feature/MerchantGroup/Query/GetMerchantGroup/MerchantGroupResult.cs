namespace TCCPOS.Backend.InventoryService.Application.Feature.ShopGroup.Query.GetShopGroup
{
    public class MerchantGroupResult
    {
        public string? TargetID { get; set; }
        public string? SkuID { get; set; }
        public string? SkuName { get; set; }
        public int? Target { get; set; }
        public string? RewardID {get;set;}
        public string? Reward { get; set; }
        public DateTime? ResetDate { get; set; }
    }
}
