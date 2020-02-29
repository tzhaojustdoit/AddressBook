using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

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

        // List of administrative areas.
        [BsonElement("AdminAreas")]
        public List<string> AdminAreas { get; set; }
    }
}
