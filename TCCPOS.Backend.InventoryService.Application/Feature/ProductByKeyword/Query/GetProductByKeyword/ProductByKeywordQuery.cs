using MediatR;


namespace TCCPOS.Backend.InventoryService.Application.Feature.ProductByKeyword.Query.GetProductByKeyword
{
    public class GetProductByKeywordQuery : IRequest<List<ProductByKeywordResult>>
    {
        public string? keyword { get; set; }
      
        public GetProductByKeywordQuery(string keyword)
        
{
        this.keyword = keyword;
}
           

        
    }
}
