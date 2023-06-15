using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Supplier.Query.GetSupplier
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, List<SupplierResult>>
    {
        private readonly ILogger<GetSupplierQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetSupplierQueryHandler(ILogger<GetSupplierQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<SupplierResult>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _repo.GetSupplier(); // Call the GetSupplier method in your repository

            return suppliers.ToList();
        }
    }
}

