namespace MicroCore.Common.Services
{
    using System.Threading.Tasks;
    
    /*  Fluent API to define type of messages, 
     commands and events to subscribe to */
    public interface IServiceHost
    {
        Task Run();
    }
}