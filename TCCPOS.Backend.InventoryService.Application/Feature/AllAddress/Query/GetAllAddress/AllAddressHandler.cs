using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Entities;

namespace TCCPOS.Backend.InventoryService.Application.Feature.AllAddress.Query.GetAllAddress
{
    public class GetAllAddressQHandler : IRequestHandler<GetAllAddressQuery, List<AllAddressResult>>
    {
        private readonly ILogger<GetAllAddressQHandler> _logger;
        IInventoryRepository _repo;

        public GetAllAddressQHandler(ILogger<GetAllAddressQHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<AllAddressResult>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Address.GetAllAddress(request.shopId);
        }
    }
}

