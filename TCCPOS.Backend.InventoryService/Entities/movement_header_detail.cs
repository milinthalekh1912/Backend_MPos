namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class movement_header_detail
    {
        public string movement_item_id { get; set; } = null!;
        public string movement_doc_no { get; set; } = null!;
        public string SKUID { get; set; } = null!;
        public decimal? QtyBefore { get; set; }
        public decimal? QtyAfter { get; set; }
    }
}
