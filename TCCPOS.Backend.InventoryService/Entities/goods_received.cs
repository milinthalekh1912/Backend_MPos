namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class goods_received
    {
        public string GoodsReceivedID { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string InvoideNumber { get; set; } = null!;
        public sbyte DocType { get; set; }
        public DateTime DocDate { get; set; }
        public string? SupplierID { get; set; }
        public DateTime ReceivedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Vat { get; set; }
        public decimal? AfterVat { get; set; }
        public string? Notes { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
