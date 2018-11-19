namespace MicroCore.Common.Commands
{
    using System.Threading.Tasks;
    
    interface ICommandHandler<in T>
     where T : ICommand
    {
        Task HandleAsync(T command);
    }
}