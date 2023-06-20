using MediatR;
namespace TCCPOS.Backend.InventoryService.Application.Feature.Categories.Query.GetCategoriesList
{
    public class GetCategoriesQuery : IRequest<GetCategoriesListResult>
    {
        public string SupplierId { get; set; } 

        public GetCategoriesQuery(string supplierId) 
        {
            SupplierId = supplierId;
        }
    }
}

