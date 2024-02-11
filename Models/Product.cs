using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIProdutoMongoDB.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        public required string Category { get; set; }
        public decimal Price { get; set; }


    }
}
