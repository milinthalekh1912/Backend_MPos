using MediatR;

namespace TCCPOS.Backend.SecurityService.Application.Feature.GeneralInfo.Query.GetGeneralInfo
{
    public class GetGeneralInfoQuery : IRequest<GeneralInfoResult>
    {
        public string Loginname { get; set; }

        public GetGeneralInfoQuery(string loginname)
        {
            Loginname = loginname;
        }
    }
}
