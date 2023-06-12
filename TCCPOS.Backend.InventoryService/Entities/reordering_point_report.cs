namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class reordering_point_report
    {
        public string BranchID { get; set; } = null!;
        public string SKUID { get; set; } = null!;
        public int? Instock { get; set; }
        public int? AverageSalesPerDay { get; set; }
        public int? AverageSalesPerWeek { get; set; }
        public DateTime? AverageOutOfStockDate { get; set; }
        public int? ProductPrepare { get; set; }
        public string? Status { get; set; }
    }
}
