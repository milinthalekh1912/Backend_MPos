namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class supplier_address
    {
        public string SupplierID { get; set; } = null!;
        public string? Address { get; set; }
        public string? Subdistrict { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? Zipcode { get; set; }
        public string? Country { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
    }
}
