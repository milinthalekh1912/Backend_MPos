
using MediatR;
namespace TCCPOS.Backend.InventoryService.Application.Feature.Sku.Query.GetAllSkuWithPriceTierByPriceTierID
{
    public class GetAllSkuWithPriceTierByPriceTierIDQuery : IRequest<GetAllSkuWithPriceTierByPriceTierIDResult>
    {
        public string SupplierID { get; set; }
        public string PriceTierID { get; set; }
       
        public GetAllSkuWithPriceTierByPriceTierIDQuery(string supplierId, string priceTierId)
        {
           SupplierID = supplierId;
            PriceTierID = priceTierId;
        }
    }
}
