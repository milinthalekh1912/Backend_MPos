namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class supplier_branch
    {
        public string SupplierID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string? Name { get; set; }
        public string? TaxID { get; set; }
        public string? AddressInfo { get; set; }
        public string? Subdistrict { get; set; }
        public string? District { get; set; }
        public string? Province { get; set; }
        public string? Zipcode { get; set; }
    }
}
