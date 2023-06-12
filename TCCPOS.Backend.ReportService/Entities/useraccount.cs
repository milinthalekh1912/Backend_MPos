namespace TCCPOS.Backend.ReportService.Entities
{
    public partial class useraccount
    {
        public useraccount()
        {
            userlogin = new HashSet<userlogin>();
        }

        public string UserID { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? LastLogin { get; set; }
        public string? AuthType { get; set; }
        public string? UserType { get; set; }
        public int? FailedCount { get; set; }
        public string CreateBy { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; } = null!;
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<userlogin> userlogin { get; set; }
    }
}
