using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID
{
    public class GetSkuListByCategoryIdQuery : IRequest<GetSkuListResult>
    {
        public string SupplierID { get; set; }
        public string CategoryID { get; set; }
        public GetSkuListByCategoryIdQuery(string supplierId,string categoryID)
        {
            SupplierID = supplierId;
            CategoryID = categoryID;
        }
    }
}

