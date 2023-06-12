namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class branch
    {
        public branch()
        {
            posclient = new HashSet<posclient>();
        }

        public string BranchID { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string BranchNo { get; set; } = null!;
        public string? BranchName { get; set; }
        public string? BranchAddress { get; set; }
        public string? BranchEmail { get; set; }
        public string? AccountName { get; set; }
        public string? AccountCode { get; set; }
        public bool IsActive { get; set; }
        public string? BranchAddress2 { get; set; }
        public string? BranchSubdistrict { get; set; }
        public string? BranchDistrict { get; set; }
        public string? BranchProvince { get; set; }
        public string? BranchZipcode { get; set; }
        public sbyte? IsInventory { get; set; }
        public sbyte? IsAlertInventory { get; set; }
        public string? BranchAddress1 { get; set; }

        public virtual ICollection<posclient> posclient { get; set; }
    }
}
