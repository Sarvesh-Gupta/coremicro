namespace MicroCore.Common.Mongo
{
    using System.Threading.Tasks;
    public interface IDatabaseInitializer
    {
         Task Init();
    }
}