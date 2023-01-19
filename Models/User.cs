using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyUserApp.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;
    }
}