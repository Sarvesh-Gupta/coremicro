namespace MicroCore.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {
        protected CreateActivityRejected()
        {
            
        }

        public CreateActivityRejected(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }
        public string Reason { get; }

        public string Code { get; }
    }
}