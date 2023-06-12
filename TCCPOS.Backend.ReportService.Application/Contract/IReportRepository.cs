namespace TCCPOS.Backend.ReportService.Application.Contract
{
    public interface IReportRepository
    {
        Task SaveChangeAsyncWithCommit();


    }
}
