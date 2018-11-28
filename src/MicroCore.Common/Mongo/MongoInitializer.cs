namespace MicroCore.Common.Mongo
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Conventions;
    using MongoDB.Driver;

    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _isInitialized;
        private readonly bool _seed;

        private readonly IMongoDatabase _database;

        public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options)
        {
            _database = database;
            _seed = options.Value.Seed;
        }
        public async Task Init()
        {
            if (_isInitialized)
            {
                return;
            }

            RegisterConventions();

            _isInitialized = true;

            if (!_seed)
            {
                return;
            }

            await Seed();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("MicroCoreConventions", new MongoConventions(), x => true);
        }

        private async Task Seed()
        {
            await Task.CompletedTask;
        }

        private class MongoConventions : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}