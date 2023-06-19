using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;


namespace TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryResult>>
    {
        private readonly ILogger<GetCategoryQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetCategoryQueryHandler(ILogger<GetCategoryQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<CategoryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Categories.GetCategoryBySupplierIdAsync(request.SupplierId);
        }
    }
}