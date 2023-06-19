using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion;
using TCCPOS.Backend.InventoryService.Entities;


namespace TCCPOS.Backend.InventoryService.Infrastructure.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        protected readonly InventoryContext _context;
        DateTime _dtnow;


        public PromotionRepository(InventoryContext context, DateTime _dtnow)
        {
            _context = context;
            _dtnow = DateTime.Now;
        }

        public async Task SaveChangeAsyncWithCommit()
        {
            if (_context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                _context.Database.SetCommandTimeout(120);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<PromotionResult>> GetPromotion()
        {
            var promotions = await _context.promotion.Where(x => true).ToListAsync();
            List<PromotionResult> result = new List<PromotionResult>();

            foreach (var promotion in promotions)
            {
                PromotionResult obj = new PromotionResult();
                obj.promotionId = promotion.promotion_id;
                obj.promotionType = promotion.promotion_type;
                obj.promotionDescription = new List<PromotionResult.PromotionDetails>();

                var promotionConditions = promotion.conditions?.Split(',').ToList();


                foreach (var condition in promotionConditions)
                {
                    var skus = await _context.sku.Where(y => true).ToListAsync();

                    if (skus != null)
                    {
                        PromotionResult.PromotionDetails promotionDetail = new PromotionResult.PromotionDetails
                        {
                            condition = condition,
                            groupSkuA = new List<PromotionResult.PromotionDetails.GroupSku>()
                        };

                        foreach (var sku in skus)
                        {
                            PromotionResult.PromotionDetails.GroupSku groupSku = new PromotionResult.PromotionDetails.GroupSku
                            {
                                title = sku.title,
                                sku = sku.sku_id,
                                barcode = sku.barcode,
                                imageUrl = sku.image_url,
                                aliasTitle = sku.alias_title
                            };

                            promotionDetail.groupSkuA.Add(groupSku);
                        }

                        obj.promotionDescription.Add(promotionDetail);
                    }
                }


                result.Add(obj);
            }

            return result;
        }

    }
}




