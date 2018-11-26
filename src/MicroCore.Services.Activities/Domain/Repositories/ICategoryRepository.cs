namespace MicroCore.Services.Activities.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MicroCore.Services.Activities.Domain.Models;
    public interface ICategoryRepository
    {
        Task<Category> Get(string name);

        Task<IEnumerable<Category>> Browse();

        Task Add(Category category);
    }
}