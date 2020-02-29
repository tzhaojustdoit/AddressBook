using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AddressBook.Data
{
    public class Country
    {
        // Unique id, primary key.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // Country name.
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
