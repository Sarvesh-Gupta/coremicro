namespace MicroCore.Services.Activities.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MicroCore.Services.Activities.Domain.Models;
    using MicroCore.Services.Activities.Domain.Repositories;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");

        public async Task<Category> Get(string name)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant() );

        public async Task Add(Category category)
            => await Collection.InsertOneAsync(category);
        public async Task<IEnumerable<Category>> Browse()
            => await Collection.AsQueryable().ToListAsync();
    }
}