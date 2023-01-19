using MongoDB.Driver;
using MyUserApp.Models;

namespace MyUserApp.Interface
{
    public interface UserListInterface
    {
        IMongoCollection<User> usersCollection { get; }
        IEnumerable<User> GetUsers();
        User Get(string name);
        void Create(User user);
    }
}
