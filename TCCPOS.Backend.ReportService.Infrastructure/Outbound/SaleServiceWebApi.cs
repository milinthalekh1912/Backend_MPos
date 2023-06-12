/*using System.Net.Http.Headers;
using TCCPOS.Backend.ReportService.Application.Contract;
using TCCPOS.Backend.ReportService.Contract.SaleService;

namespace TCCPOS.Backend.ReportService.Infrastructure.Outbound
{
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

        public async Task<BranchListResult> GetBranchAsync()
        {
            var client = GetServiceClient();
            var res = await client.BranchAsync();
            return res;
        }

        public async Task<SKUListResult> GetAllSku()
        {
            var client = GetServiceClient();
            var res = await client.SKUGETAsync();
            return res;
        }
        public async Task<SKUItemResult> GetSkuByID(string skuID)
        {
            var client = GetServiceClient();
            var res = await client.SKUGET2Async(skuID);
            return res;
        }

    }
}
*/