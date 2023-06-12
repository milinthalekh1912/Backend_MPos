namespace TCCPOS.Backend.SecurityService.Application.Feature.LoginWithLine.Command.LoginWithLine
{
    public class LoginWithLineResult
    {
        public string Token { get; set; } = "";
        public DateTime Expiration { get; set; }
    }
}
