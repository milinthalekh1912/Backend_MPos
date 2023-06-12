namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class supplier_sku
    {
        public string SupplierID { get; set; } = null!;
        public string SKUID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string? IsActive { get; set; }
    }
}
