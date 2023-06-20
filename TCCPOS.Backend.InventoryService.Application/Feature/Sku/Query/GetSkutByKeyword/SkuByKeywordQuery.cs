using MediatR;


namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword
{
    public class GetSkuByKeywordQuery : IRequest<List<SkuByKeywordResult>>
    {
        public string? keyword { get; set; }
      
        public GetSkuByKeywordQuery(string keyword)
        
{
        this.keyword = keyword;
}
           

        
    }
}
