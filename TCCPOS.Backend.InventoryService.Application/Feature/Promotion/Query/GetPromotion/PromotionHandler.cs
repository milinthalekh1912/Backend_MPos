using MediatR;
using Microsoft.Extensions.Logging;

using TCCPOS.Backend.InventoryService.Application.Contract;


namespace TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion
{
    public class GetPromotionQueryHandler : IRequestHandler<GetPromotionQuery, List<PromotionResult>>
    {
        private readonly ILogger<GetPromotionQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetPromotionQueryHandler(ILogger<GetPromotionQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<PromotionResult>> Handle(GetPromotionQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _repo.GetPromotion(); // Call the GetSupplier method in your repository

            return promotion.ToList();
        }
    }
}

