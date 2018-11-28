namespace MicroCore.Services.Activities.Repositories
{
    using System;
    using System.Threading.Tasks;
    using MicroCore.Services.Activities.Domain.Models;
    using MicroCore.Services.Activities.Domain.Repositories;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        public async Task Add(Activity activity)
            => await Collection.InsertOneAsync(activity);
    }
}