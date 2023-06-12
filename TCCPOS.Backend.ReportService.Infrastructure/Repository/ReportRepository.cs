using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.ReportService.Application.Contract;

namespace TCCPOS.Backend.ReportService.Infrastructure.Repository
{
    public class ReportRepository : IReportRepository
    {
        protected readonly ReportContext _context;
        DateTime _dtnow;

        public ReportRepository(ReportContext context)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

    }
}
