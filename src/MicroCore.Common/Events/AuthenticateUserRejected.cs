namespace MicroCore.Common.Events
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        protected AuthenticateUserRejected()
        {
            
        }

        public AuthenticateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}