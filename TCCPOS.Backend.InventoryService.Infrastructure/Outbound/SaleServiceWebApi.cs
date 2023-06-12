/*using System.Net.Http.Headers;
using TCCPOS.Backend.InventoryService.Application.Contract;
using TCCPOS.Backend.InventoryService.Contract.SaleService;
*/
//namespace TCCPOS.Backend.InventoryService.Infrastructure.Outbound
/*{
    public class SaleServiceWebApi : ISaleServiceWebApi
    {
        string _baseurl;
        string _authorization;

        public SaleServiceWebApi(string baseurl, string authorization)
        {
            _baseurl = baseurl;
            _authorization = authorization;
        }

        private SaleServiceWebApiClient GetServiceClient()
        {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorization);
            return new SaleServiceWebApiClient(_baseurl, httpclient);
        }

        public async Task<SKUListResult> GetSKUAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.SKUGETAsync();
            return res;
        }
        public async Task<SKUListResult> GetSKUPassPriceAsync()
        {
            var client = GetServiceClient();
            var res = await client.SKUGETAsync();
            return res;
        }

        public async Task<ICollection<ProductGroupResult>> GetProductGroupAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.ProductGroupAllAsync();
            return res;
        }
        public async Task<ICollection<ProductCatResult>> GetProductCateAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.ProductCatAllAsync();
            return res;
        }

        public async Task<BrandListResult> GetBrandAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.BrandGETAsync();
            return res;
        }

        public async Task<BranchListResult> GetBranchAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.BranchAsync();
            return res;
        }

        public async Task<BranchDetailResult> GetBranchDetailAsync()
        {
            var client = GetServiceClient();
            var res = await client.DetailGETAsync();
            return res;
        }

        public async Task<BranchDetailResult> GetIsInventory()
        {
            var client = GetServiceClient();
            var res = await client.DetailGETAsync();
            return res;
        }
        public async Task<UpsertBranchResult> UpdateIsInventory(UpsertBranchRequest command)
        {
            var client = GetServiceClient();
            var res = await client.DetailPOSTAsync(command);
            return res;
        }

        public async Task<SaleOrderListResult> GetSaleItemResultAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.SaleOrderGETAsync();
            return res;
        }

        public async Task<ICollection<ProductSubCatResult>> GetSubCatAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.ProductSubCatAllAsync();
            return res;
        }
    }
}*/
