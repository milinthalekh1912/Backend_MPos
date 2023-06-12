namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class sku_branch_inventory_config
    {
        public string SKUID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public decimal? TriggerLowlevelQTY { get; set; }
        public decimal? MaximumLowlevelQTY { get; set; }
        public decimal? NegativeQTY { get; set; }
        public sbyte? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }
}
