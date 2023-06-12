namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class sku_branch_inventory
    {
        public string SKUID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public decimal CurrentQTY { get; set; }
        public decimal AccumValue { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal? DeadStockQTY { get; set; }
        public DateTime? LastCountDate { get; set; }
        public string branch_location_id { get; set; } = null!;
    }
}
