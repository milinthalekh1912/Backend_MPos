namespace TCCPOS.Backend.InventoryService.Application.Feature.Target.Query.GetTarget
{
    public class TargetResult
    {
        public string? ShopId { get; set; }
        public int? Target { get; set; }
        public int? CurrentSpent { get; set; }
        public string? RewardID {get;set;}
        public string? SkuId { get; set; }
        public string? SkuName { get; set; }
        public string? Reward { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
