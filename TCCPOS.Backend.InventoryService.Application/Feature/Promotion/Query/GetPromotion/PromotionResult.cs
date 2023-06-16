using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCPOS.Backend.InventoryService.Application.Feature.Promotion.Query.GetPromotion
{
    public class PromotionResult
    {
        public string? promotionId { get; set; }
        public int? promotionType { get; set; }
        public List<PromotionDetails>? promotionDescription { get; set; }
        public class PromotionDetails
        {
            public string? condition { get; set; }
            public List<GroupSku>? groupSkuA { get; set; }
            public class GroupSku
            {
                public string? title { get; set; }
                public string? aliasTitle { get; set; }
                public string? sku { get; set; }
                public string? barcode { get; set; }
                public string? imageUrl { get; set; }
            }
        }


    }
}
