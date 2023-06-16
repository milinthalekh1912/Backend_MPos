using MediatR;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdResult>
    {
        public string ShopId { get; set; }

        public GetAddressByIdQuery(string shopid)
        {
            ShopId = shopid;
        }
    }
}