using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress
{
    public class GetAllAddressQuery : IRequest<GetListAddressResult>
    {
        public string shopId { get; set; }
    }
}
