using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.SKU.Query.GetSkuListByCategoriesID
{
    public class GetSkuListByCategoryIdQuery : IRequest<GetSkuListResult>
    {
        public string MerchantID { get; set; }
        public string SupplierID { get; set; }
        public string CategoryID { get; set; }
        public GetSkuListByCategoryIdQuery(string merchantId,string supplierId,string categoryID)
        {
            MerchantID = merchantId;
            SupplierID = supplierId;
            CategoryID = categoryID;
        }
    }
}

