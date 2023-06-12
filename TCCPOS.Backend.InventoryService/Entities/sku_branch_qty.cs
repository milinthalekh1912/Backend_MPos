namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class sku_branch_qty
    {
        public string BranchID { get; set; } = null!;
        public string? BarcodePOS { get; set; }
        public decimal? CurrentQTY { get; set; }
        public decimal? AccumValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public decimal? DeadStockQTY { get; set; }
        public DateTime? LastCountDate { get; set; }
        public int? BranchLocationID { get; set; }
    }
}
