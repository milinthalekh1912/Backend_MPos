namespace TCCPOS.Backend.SecurityService.Application.Feature.POSConfig.Query.GetPOSConfig
{
    public class POSConfigResult
    {
        public string POSClientID { get; set; } = null!;
        public string BranchID { get; set; } = null!;
        public string BranchNo { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string? BranchAddress { get; set; }
        public string? AccountName { get; set; }
        public string? AccountCode { get; set; }
        public string MerchantID { get; set; } = null!;
        public string MerchantName { get; set; } = null!;
        public string TaxID { get; set; } = null!;
        public bool? IsDrawer { get; set; }
        public bool? IsBarcode { get; set; }

        public bool? IsCash { get; set; } = null;
        public bool? IsQRCode { get; set; }
        public string? promtpayAccountName { get; set; } = null;
        public string? promtpayNo { get; set; } = null;
        public bool? IsPaoTang { get; set; } = null;
        public bool? IsTongFah { get; set; } = null;
        public bool? IsCoupon { get; set; } = null;

        public sbyte? SessionType { get; set; }
        public sbyte? BarcodeReaderType { get; set; }
        public sbyte? PrinterType { get; set; }
        public bool IsActive { get; set; }

        public string POSRunning { get; set; } = null!;
        public string POSRunningFR { get; set; } = null!;

        public bool IsVat { get; set; }
        public string? RDNumber { get; set; }

        //public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? subDistrict { get; set; }
        public string? district { get; set; }
        public string? province { get; set; }
        public string? zipcode { get; set; }

        public sbyte? IsInventory { get; set; } = null;
        public sbyte? IsAlertInventory { get; set; } = null;

        public sbyte? paymentMode { get; set; } = 0;

        public string? token { get; set; } = null;
    }
}