namespace TCCPOS.Backend.InventoryService.Entities
{
    public partial class supplier
    {
        public string SupplierID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string TaxID { get; set; } = null!;
        public string? BranchNo { get; set; }
        public string ContactName { get; set; } = null!;
        public string? Mobile { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
    }
}
