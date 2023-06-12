/*using System.Net.Http.Headers;
using TCCPOS.Backend.ReportService.Application.Contract;
using TCCPOS.Backend.ReportService.Application.Exceptions;
using TCCPOS.Backend.ReportService.Contract.InventoryService;

namespace TCCPOS.Backend.ReportService.Infrastructure.Outbound
{
    public class InventoryServiceWebApi : IInventoryServiceWebApi
    {
        string _baseurl;
        string _authorization;

        public InventoryServiceWebApi(string baseurl, string authorization)
        {
            _baseurl = baseurl;
            _authorization = authorization;
        }

        private InventoryServiceWebApiClient GetServiceClient()
        {
            var httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorization);
            return new InventoryServiceWebApiClient(_baseurl, httpclient);
        }

        public async Task<ICollection<GetPhysicalCountStatusListResult>> StatusAllAsync()
        {
            var client = GetServiceClient();
            var res = await client.StatusAllAsync();
            return res;
        }

        public async Task<GetGoodsLostListResult> GetGoodsLost()
        {
            var client = GetServiceClient();
            var res = await client.GoodsLostAsync();
            return res;
        }
        public async Task<GetSkuBranchInventoryConfigResult> GetSkuBranchInventoryConfig(string skuId)
        {
            var client = GetServiceClient();
            try
            {
                var res = await client.SkuBranchInventoryConfigGETAsync(skuId);
                return res;
            }
            catch (Exception ex)
            {
                ApiException<FailedResult> apiException = (ApiException<FailedResult>)ex;
                throw ReportServiceException.RE003(apiException.Result.ErrorDetail);
            }
        }

        public async Task<GetReorderingReportResult> GetReorderingDetail()
        {
            var client = GetServiceClient();
            var res = await client.ReorderingAsync();

            return res;
        }
    }
}
*/