using MediatR;
using Microsoft.Extensions.Logging;
using TCCPOS.Backend.InventoryService.Application.Contract;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotionLineOA
{ 
    public class GetPromotionLineOAQueryHandler : IRequestHandler<GetPromotionLineOAQuery, GetPromotionLineOAResult>
    {
        private readonly ILogger<GetPromotionLineOAQueryHandler> _logger;
        IInventoryRepository _repo;

        public GetPromotionLineOAQueryHandler(ILogger<GetPromotionLineOAQueryHandler> logger, IInventoryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<GetPromotionLineOAResult> Handle(GetPromotionLineOAQuery request, CancellationToken cancellationToken)
        {
            var res = new GetPromotionLineOAResult();

            var query = await _repo.Promotion.GetPromotionLineOA();
            foreach (var promotion_obj in query) 
            {
                var item = new PromotionLineOAItemResult();
                item.PromotionID = promotion_obj.promotion_id;
                item.Title = promotion_obj.description ?? "";
                item.description = promotion_obj.description ?? "";
                item.UrlImg = promotion_obj.description ?? "";
                res.items.Add(item);    
            }

            return res;
        }
    }
}
