using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Exceptions;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAllAddress
{
    public class GetAllAddressQHandler : IRequestHandler<GetAllAddressQuery, GetListAddressResult>
    {
        private readonly ILogger<GetAllAddressQHandler> _logger;
        IInventoryRepository _repo;

        public GetAllAddressQHandler(ILogger<GetAllAddressQHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetListAddressResult> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            var shopAddressList = await _repo.Address.GetAllAddress(request.shopId);
            if (shopAddressList == null || !shopAddressList.Any())
            {
                throw InventoryServiceException.IE001;
            }

            var results = new GetListAddressResult();

            foreach (var item in shopAddressList)
            {
                AddressResult obj = new AddressResult();
                obj.addressId = item.address_id;
                obj.shopTitle = item.shop_title;
                obj.address1 = item.address1;
                obj.address2 = item.address2;
                obj.address3 = item.address3;
                obj.zipcode = item.zipcode;
                obj.phoneNumber = item.phone_number;
                results.items.Add(obj);
            }
            return results;
        }
    }
}

