using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoriesListResult>
    {
        private readonly ILogger<GetCategoryQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetCategoryQueryHandler(ILogger<GetCategoryQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<CategoriesListResult> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repo.Categories.GetCategoryBySupplierIdAsync(request.SupplierId);

            if (categories == null || !categories.Any()) { throw InventoryServiceException.IE001; }

            var results = new CategoriesListResult();

            foreach (var category in categories)
            {
                CategoryResult item = new CategoryResult();
                item.CategoryId = category.category_id ?? "";
                item.CategoryNameTH = category.th_name ?? "";
                item.CategoryNameEN = category.en_name ?? "";
                results.items.Add(item);

            }
            return results;
        }
    }
}