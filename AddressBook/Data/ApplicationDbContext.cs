
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ApplicationDbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("AddressBookData");
        }

        public IMongoCollection<Address> AddressRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Address>("Addresses");
            }
        }

        public IMongoCollection<CountryFormat> CountryRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<CountryFormat>("Countries");
            }
        }
    }
}
