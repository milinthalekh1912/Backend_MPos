using System;
using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductByCat.Query.GetProductByCat
{
    public class GetProductByCatHandler : IRequestHandler<GetProductByCatQuery, List<GetProductByCatResult>>
    {
        private readonly ILogger<GetProductByCatHandler> _logger;
        IInventoryRepository _repo;

        public GetProductByCatHandler(ILogger<GetProductByCatHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<GetProductByCatResult>> Handle(GetProductByCatQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetProductBycat(request.categoryId, request.supplierId, request.shopId);
        }
    }
}
