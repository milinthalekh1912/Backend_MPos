using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Categories.Query.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesListResult>
    {
        private readonly ILogger<GetCategoriesListQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetCategoriesListQueryHandler(ILogger<GetCategoriesListQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetCategoriesListResult> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var res = new GetCategoriesListResult();
            var categories_query = await _repo.Categories.GetCategoryBySupplierIdForLine(request.SupplierId);
            foreach (var category in categories_query) 
            {
                var item = new CategoriesItemResult();
                item.CategoriesID = category.category_id;
                
                item.TH_Title = category.th_name ?? "";
                item.EN_Title = category.en_name ?? "";
                item.TH_Description = category.description ?? "";
                item.EN_Description = category.description ?? "";
                item.UrlImg = category.image_url ?? "";
                res.items.Add(item);
            }
            return res;
        }
    }
}
