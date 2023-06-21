using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.PriceTier.Query.GetAllPriceTierGroup
{
    public class GetAllPriceTierGroupQuery : IRequest<GetAllPriceTierGroupResult>
    {
        public string SupplierID { get; set; }
        public GetAllPriceTierGroupQuery(string suppierId)
        {
            SupplierID = suppierId;
        }
    }
}


