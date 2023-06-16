using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress
{
    public class GetAllAddressQuery : IRequest<List<AllAddressResult>> 
    {
        public string shopId { get; set; }
    }
}
