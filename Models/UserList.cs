using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyUserApp.Interface;

namespace MyUserApp.Models
{
    public class UserList : UserListInterface
    {
        public readonly IMongoDatabase _db;

        public UserList(IOptions<UserDatabaseSetting> UserDatabaseSettings)
        {
            var mongoClient = new MongoClient(UserDatabaseSettings.Value.ConnectionString);
            _db = mongoClient.GetDatabase(UserDatabaseSettings.Value.Database);
        }

        public IMongoCollection<User> usersCollection => _db.GetCollection<User>("User");

        public void Create(User user)
        {
            usersCollection.InsertOne(user);
        }

        public User Get(string name)
        {
            var obj = usersCollection.Find(m => m.Name == name).FirstOrDefault();
            return obj;
        }

        public IEnumerable<User> GetUsers()
        {
            return usersCollection.Find(a => true).ToList();
        }
    }
}
