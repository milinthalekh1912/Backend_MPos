using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Address.Query.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdResult>
    {
        private readonly ILogger<GetAddressByIdQueryHandler> _logger;
        IInventoryRepository _repo;
        IConfiguration _config;

        public GetAddressByIdQueryHandler(ILogger<GetAddressByIdQueryHandler> logger, IInventoryRepository repo, IConfiguration config)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
        }

        public async Task<GetAddressByIdResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _repo.Address.GetAddressById(request.ShopId);

            return new GetAddressByIdResult()
            {
                addressId = address?.address_id,
                address1 = address?.address1,
                address2 = address?.address2,
                address3 = address?.address3,
                zipcode = address?.zipcode
            };

        }
    }
}
