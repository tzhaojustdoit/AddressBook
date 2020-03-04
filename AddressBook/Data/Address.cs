using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AddressBook.Data
{
    public class Address
    {
        // Unique id, primary key.
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // Country name.
        [BsonElement("country")]
        [Required]
        public string Country { get; set; }

        // The address lines represent the most specific part of any address.
        [BsonElement("addressLine1")]
        public string AddressLine1 { get; set; }

        // Address line 2.
        [BsonElement("addressLine2")]
        public string AddressLine2 { get; set; }

        // Address line 3.
        [BsonElement("addressLine3")]
        public string AddressLine3 { get; set; }

        // Any extra data.
        [BsonElement("extraData")]
        public string ExtraData { get; set; }

        // Top-level administrative subdivision of this country.
        [BsonElement("adminArea")]
        public string AdminArea { get; set; }

        // Generally refers to the city/town portion of an address.
        [BsonElement("locality")]
        public string Locality { get; set; }

        // Generally refers to the sub-city portion of an address.
        [BsonElement("sublocality")]
        public string Sublocality { get; set; }

        // Values are frequently alphanumeric.
        [BsonElement("postalCode")]
        public string PostalCode { get; set; }
    }
}
