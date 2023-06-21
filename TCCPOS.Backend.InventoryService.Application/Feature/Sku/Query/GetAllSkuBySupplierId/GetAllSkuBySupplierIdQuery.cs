
using MediatR;
namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuBySupplierId
{
    public class GetAllSkuBySupplierIdQuery : IRequest<GetAllSkuResult>
    {
        public string MerchantID { get; set; }
        public string SupplierID { get; set; }
       
        public GetAllSkuBySupplierIdQuery(string merchantId,string supplierId)
        {
            MerchantID = merchantId;
            SupplierID = supplierId;
        }
    }
}
