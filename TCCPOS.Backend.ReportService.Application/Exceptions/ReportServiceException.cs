namespace TCCPOS.Backend.ReportService.Application.Exceptions
{
    public class ReportServiceException : ApplicationException
    {
        public static ReportServiceException RE001 { get; } = new ReportServiceException(nameof(RE001), "Invalid date.");
        public static ReportServiceException RE002 { get; } = new ReportServiceException(nameof(RE002), "");
        public static ReportServiceException RE003(string innerexception)
        {
            return new ReportServiceException(nameof(RE003), "Exception API : " + innerexception); // Duplicate entry
        }

        public string Code { get; set; }
        private ReportServiceException(string code) : base()
        {
            Code = code;
        }
        private ReportServiceException(string code, string message) : base(message)
        {
            Code = code;
        }
        private ReportServiceException(string code, string message, Exception innerexception) : base(message, innerexception)
        {
            Code = code;
        }

    }
}
