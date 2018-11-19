namespace MicroCore.Common
{
    public interface IAuthenticatedCommand : ICommand
    {
        int UserId { get; set; }
    }
}