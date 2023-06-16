using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Category.Query.GetAllCategory
{
    public class GetCategoryQuery : IRequest<List<CategoryResult>>
    {
        public string SupplierId { get; set; }

        public GetCategoryQuery(string supplierId)
        {
            SupplierId = supplierId;
        }
    }
}