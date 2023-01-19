using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyUserApp.Models;

namespace MyUserApp.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(
            IOptions<UserDatabaseSetting> UserDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                UserDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                UserDatabaseSettings.Value.Database);

            _usersCollection = mongoDatabase.GetCollection<User>(
                UserDatabaseSettings.Value.Collection);
        }
        public async Task CreateAsync(User user)=>
        
            await _usersCollection.InsertOneAsync(user);
        
    }
}
