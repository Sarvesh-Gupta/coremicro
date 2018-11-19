namespace MicroCore.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        int UserId { get; set; }
    }
}