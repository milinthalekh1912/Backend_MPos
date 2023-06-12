namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class goods_received_detail
    {
        public string GoodsReceivedDetailID { get; set; } = null!;
        public string GoodsReceivedID { get; set; } = null!;
        public string SKUID { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string BranchLocationID { get; set; } = null!;
    }
}
