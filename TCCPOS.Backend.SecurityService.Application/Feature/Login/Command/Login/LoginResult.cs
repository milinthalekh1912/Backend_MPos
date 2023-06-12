namespace TCCPOS.Backend.SecurityService.Application.Feature.Login.Command.Login
{
    public class LoginResult
    {
        public string Username { get; set; } = "";
        public string Token { get; set; } = "";
        public DateTime Expiration { get; set; }
    }
}
