namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class physical_count_detail
    {
        public string PhysicalCountDetailID { get; set; } = null!;
        public string PhysicalCountID { get; set; } = null!;
        public string SKUID { get; set; } = null!;
        public decimal BeforeQTY { get; set; }
        public decimal Quantity { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
