using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory
{
    public class GetCategoryQuery : IRequest<CategoriesListResult>
    {
        public string SupplierId { get; set; }

        public GetCategoryQuery(string supplierId)
        {
            SupplierId = supplierId;
        }
    }
}