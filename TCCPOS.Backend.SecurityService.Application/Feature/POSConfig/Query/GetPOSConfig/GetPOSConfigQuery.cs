using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.POSConfig.Query.GetPOSConfig
{
    public class GetPOSConfigQuery : IRequest<POSConfigResult>
    {
        public string POSClientID { get; set; }

        public GetPOSConfigQuery(string posclientid)
        {
            POSClientID = posclientid;
        }
    }
}
