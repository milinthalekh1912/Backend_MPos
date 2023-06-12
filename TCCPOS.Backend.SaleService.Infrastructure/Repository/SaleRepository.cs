using Microsoft.EntityFrameworkCore;
using TCCPOS.Backend.SaleService.Application.Contract;

namespace TCCPOS.Backend.SaleService.Infrastructure.Repository
{
    public class SaleRepository : ISaleRepository
    {
        protected readonly SaleContext _context;
        DateTime _dtnow;

        public SaleRepository(SaleContext context)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

    }
}
