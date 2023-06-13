namespace TCCPOS.Backend.SecurityService.Application.Exceptions
{
    public class SecurityServiceException : ApplicationException
    {
        public static SecurityServiceException SE001 { get; } = new SecurityServiceException(nameof(SE001), "Username not found.");
        public static SecurityServiceException SE002 { get; } = new SecurityServiceException(nameof(SE002), "Password not match.");
        public static SecurityServiceException SE003 { get; } = new SecurityServiceException(nameof(SE003), "Username is inactive.");
        public static SecurityServiceException SE004 { get; } = new SecurityServiceException(nameof(SE004), "Cannot login with system account.");
        public static SecurityServiceException SE005 { get; } = new SecurityServiceException(nameof(SE005), "The user does not belong to any POS client.");
        public static SecurityServiceException SE006 { get; } = new SecurityServiceException(nameof(SE006), "The user does not belong to this POS client.");
        public static SecurityServiceException SE007 { get; } = new SecurityServiceException(nameof(SE007), "Invalid POSClient ID.");
        public static SecurityServiceException SE008 { get; } = new SecurityServiceException(nameof(SE008), "POSClient is inactive.");
        public static SecurityServiceException SE009 { get; } = new SecurityServiceException(nameof(SE009), "No version defined.");
        public static SecurityServiceException SE010 { get; } = new SecurityServiceException(nameof(SE010), "Invalid Branch ID.");
        public static SecurityServiceException SE011 { get; } = new SecurityServiceException(nameof(SE011), "Branch is inactive.");
        public static SecurityServiceException SE012 { get; } = new SecurityServiceException(nameof(SE012), "Invalid Merchant ID.");
        public static SecurityServiceException SE013 { get; } = new SecurityServiceException(nameof(SE013), "Merchant is inactive.");
        public static SecurityServiceException SE014 { get; } = new SecurityServiceException(nameof(SE014), "The user not login yet.");
        public static SecurityServiceException SE015 { get; } = new SecurityServiceException(nameof(SE015), "The userLogin not found.");
        public static SecurityServiceException SE016 { get; } = new SecurityServiceException(nameof(SE016), "The userAccount not found.");
        public static SecurityServiceException SE017 { get; } = new SecurityServiceException(nameof(SE017), "Username already exists.");
        public static SecurityServiceException SE018 { get; } = new SecurityServiceException(nameof(SE018), "Line AccessToken is not valid");
        public static SecurityServiceException SE019 { get; } = new SecurityServiceException(nameof(SE019), "This User already have Shop");


        public string Code { get; set; }
        private SecurityServiceException(string code) : base()
        {
            Code = code;
        }
        private SecurityServiceException(string code, string message) : base(message)
        {
            Code = code;
        }
        private SecurityServiceException(string code, string message, Exception innerexception) : base(message, innerexception)
        {
            Code = code;
        }

    }
}
