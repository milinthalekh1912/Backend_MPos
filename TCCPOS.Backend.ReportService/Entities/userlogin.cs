
namespace TCCPOS.Backend.ReportService.Entities
{
    /// <summary>
    /// ผูก User กับ POSClient เข้าด้วยกัน, User นี้ใช้ POSClient ไหนได้บ้าง
    /// </summary>
    public partial class userlogin
    {
        public string UserID { get; set; } = null!;
        public string POSClientID { get; set; } = null!;
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public string? Version { get; set; }

        public virtual posclient POSClient { get; set; } = null!;
        public virtual useraccount User { get; set; } = null!;
    }
}
