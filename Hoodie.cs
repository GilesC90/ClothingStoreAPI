using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClothingStoreApi.Models
{
    public class Hoodie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Brand {get; set; } = null!;
        
        [BsonElement("Item Name")]
        [JsonPropertyName("Item Name")]
        public string ItemName {get ; set; } = null!;
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}