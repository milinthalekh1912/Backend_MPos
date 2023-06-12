namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class mmitem
    {
        public string mmitem1 { get; set; } = null!;
        public string mmdoc { get; set; } = null!;
        public string? SKUID { get; set; }
        public decimal? LastInventoyValue { get; set; }
        public decimal? BeforeQTY { get; set; }
        public decimal? AfterQTY { get; set; }
        public decimal? MovementQTY { get; set; }
        public decimal? CostPerQTY { get; set; }
        public string branch_location_id { get; set; } = null!;
    }
}
