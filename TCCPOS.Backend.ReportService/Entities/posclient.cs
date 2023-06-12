namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class posclient
    {
        public posclient()
        {
            possesssion = new HashSet<possesssion>();
            userlogin = new HashSet<userlogin>();
        }

        public string POSClientID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string MerchantID { get; set; } = null!;
        public string? RDNumber { get; set; }
        public bool? IsDrawer { get; set; }
        public bool? IsBarcode { get; set; }
        public bool? IsCash { get; set; }
        public bool? IsQRCode { get; set; }
        public bool? IsPaoTang { get; set; }
        public bool? IsTongFah { get; set; }
        public bool? IsCoupon { get; set; }
        public sbyte? SessionType { get; set; }
        public sbyte? BarcodeReaderType { get; set; }
        public sbyte? PrinterType { get; set; }
        public bool IsActive { get; set; }
        public string POSRunning { get; set; } = null!;
        public string FRPOSRunning { get; set; } = null!;

        public virtual branch Branch { get; set; } = null!;
        public virtual merchant Merchant { get; set; } = null!;
        public virtual ICollection<possesssion> possesssion { get; set; }
        public virtual ICollection<userlogin> userlogin { get; set; }
    }
}
