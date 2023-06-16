using MediatR;


namespace TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion
{
    public class GetPromotionQuery : IRequest<List<PromotionResult>>
    {
    }
}
