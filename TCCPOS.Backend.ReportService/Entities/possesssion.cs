namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class possesssion
    {
        public string POSSessionID { get; set; } = null!;
        public string POSClientID { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal CashAmount { get; set; }
        public sbyte? B500 { get; set; }
        public sbyte? B1000 { get; set; }
        public sbyte? B100 { get; set; }
        public sbyte? B50 { get; set; }
        public sbyte? B20 { get; set; }
        public sbyte? C10 { get; set; }
        public sbyte? C5 { get; set; }
        public sbyte? C2 { get; set; }
        public sbyte? C1 { get; set; }
        public sbyte? C050 { get; set; }
        public sbyte? C025 { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? Withdrawal { get; set; }
        public decimal? EndCashAmount { get; set; }
        public sbyte? EndB500 { get; set; }
        public sbyte? EndB1000 { get; set; }
        public sbyte? EndB100 { get; set; }
        public sbyte? EndB50 { get; set; }
        public sbyte? EndB20 { get; set; }
        public sbyte? EndC10 { get; set; }
        public sbyte? EndC5 { get; set; }
        public sbyte? EndC2 { get; set; }
        public sbyte? EndC1 { get; set; }
        public sbyte? EndC050 { get; set; }
        public sbyte? EndC025 { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual posclient POSClient { get; set; } = null!;
    }
}
