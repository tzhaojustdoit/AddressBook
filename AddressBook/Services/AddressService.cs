using AddressBook.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;



namespace AddressBook.Services
{
    public class AddressService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        #region Address

        //To Get number of addresses     
        public long GetNumOfAddresses()
        {
            try
            {
                return db.AddressRecord.CountDocuments(_ => true);
            }
            catch
            {
                throw;
            }
        }

        //To Get all address details      
        public List<Address> GetAllAddresses()
        {
            try
            {
                return db.AddressRecord.Find(_ => true).SortByDescending(a => a.Timestamp).Limit(100).ToList(); // impossible to display 1 million addresses on a single page, limit to 100 addresses
                // return db.AddressRecord.Find
                // FilterDefinition<Address> addrFilter = Builders<Address>.Filter.Eq(a => a.Timestamp);
                // return db.AddressRecord.Find(addrFilter).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new address record    
        public void CreateAddress(Address address)
        {
            try
            {
                db.AddressRecord.InsertOne(address);
            }
            catch
            {
                throw;
            }
        }

        // Get the details of a particular address     
        public Address ReadAddress(string id)
        {
            try
            {
                FilterDefinition<Address> filterAddressData = Builders<Address>.Filter.Eq("Id", id);

                return db.AddressRecord.Find(filterAddressData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        // Update the records of a particluar address     
        public void UpdateAddress(Address address)
        {
            try
            {
                db.AddressRecord.ReplaceOne(filter: g => g.Id == address.Id, replacement: address);
            }
            catch
            {
                throw;
            }
        }

        // Delete the record of a particular address     
        public void DeleteAddress(string id)
        {
            try
            {
                FilterDefinition<Address> addressData = Builders<Address>.Filter.Eq("Id", id);
                db.AddressRecord.DeleteOne(addressData);
            }
            catch
            {
                throw;
            }
        }

        // Find if the given address exist in database
        public List<Address> GetAddressByWholeAddress(Address data)
        {
            if(!String.IsNullOrEmpty(data.AddressLine2))
            {
                data.HashCode = HashCode.Combine(data.Country, data.AdminArea, data.Locality, data.AddressLine1, data.AddressLine2, data.PostalCode);
            }else{
                data.HashCode = HashCode.Combine(data.Country, data.AdminArea, data.Locality, data.AddressLine1, data.PostalCode);
            }
            //for debugging
            // Console.WriteLine("inside service get whole address function" + data.HashCode);
            FilterDefinition<Address> addrFilter = Builders<Address>.Filter.Eq(x => x.HashCode, data.HashCode);
            return db.AddressRecord.Find(addrFilter).ToList();
        }

        // Find all addresses that partially match
        public List<Address> GetAddressByPartialAddress(Address data)
        {
            FilterDefinition<Address> addrFilter = Builders<Address>.Filter.Eq(x => x.AddressLine1, data.AddressLine1); // line 1 is always required

            // add filters for all non-empty fields

            if (!string.IsNullOrEmpty(data.AddressLine2))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.AddressLine2, data.AddressLine2);
            }

            if (!string.IsNullOrEmpty(data.AddressLine3))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.AddressLine3, data.AddressLine3);
            }

            if (!string.IsNullOrEmpty(data.ExtraData))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.ExtraData, data.ExtraData);
            }

            if (!string.IsNullOrEmpty(data.AdminArea))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.AdminArea, data.AdminArea);
            }

            if (!string.IsNullOrEmpty(data.Locality))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.Locality, data.Locality);
            }

            if (!string.IsNullOrEmpty(data.Locality))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.Locality, data.Locality);
            }

            if (!string.IsNullOrEmpty(data.Sublocality))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.Sublocality, data.Sublocality);
            }

            if (!string.IsNullOrEmpty(data.PostalCode))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.PostalCode, data.PostalCode);
            }

            if (!string.IsNullOrEmpty(data.Country))
            {
                addrFilter &= Builders<Address>.Filter.Eq(x => x.Country, data.Country);
            }

            return db.AddressRecord.Find(addrFilter).ToList();
        }

        #endregion Address

        #region CountryFormat

        // To get the list of Countries 
        public List<CountryFormat> GetAllCountryFormats()
        {
            try
            {
                return db.CountryRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        // To add a new country record
        internal void CreateCountryFormat(CountryFormat country)
        {
            try
            {
                db.CountryRecord.InsertOne(country);
            }
            catch
            {
                throw;
            }
        }

        // Get the details of a particular country format     
        public CountryFormat ReadCountryFormat(string id)
        {
            try
            {
                FilterDefinition<CountryFormat> filterCountryData = Builders<CountryFormat>.Filter.Eq("Id", id);

                return db.CountryRecord.Find(filterCountryData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        // Get province/state list by country name
        public List<string> GetProvinceList(string countryName)
        {
            try{
                FilterDefinition<CountryFormat> filterCountry = Builders<CountryFormat>.Filter.Eq(x => x.Name, countryName);

                List<String> provinceList = new List<String>();

                if (filterCountry != null) 
                {
                    provinceList = db.CountryRecord.Find(filterCountry).FirstOrDefault().AdminAreas;
                }
                return provinceList;
            } 
            catch 
            {
                throw;
            }
        }

        // Update the records of a particluar country format     
        public void UpdateCountryFormat(CountryFormat countryFormat)
        {
            try
            {
                db.CountryRecord.ReplaceOne(filter: g => g.Id == countryFormat.Id, replacement: countryFormat);
            }
            catch
            {
                throw;
            }
        }

        // Delete the record of a particular country format          
        public void DeleteCountryFormat(string id)
        {
            try
            {
                FilterDefinition<CountryFormat> countryFormatData = Builders<CountryFormat>.Filter.Eq("Id", id);
                db.CountryRecord.DeleteOne(countryFormatData);
            }
            catch
            {
                throw;
            }
        }
        #endregion CountryFormat

        #region WipeAndLoad

        //To Delete all addresses
        public void DeleteAllAddresses()
        {
            try
            {
                // db.AddressRecord.DeleteManyAsync(_ => true);
                db.DeleteAddressCollection();
            }
            catch
            {
                throw;
            }
        }

        //To load all default addresses
        public void LoadDefaultAddresses()
        {
            try
            {

                var addressList = DefaultData.GetDefaultAddressList();

                db.AddressRecord.InsertManyAsync(addressList);
                
                //create index hashCode
                var key = Builders<Address>.IndexKeys;
                var indexModel = new CreateIndexModel<Address>(key.Ascending(x => x.HashCode));
                db.AddressRecord.Indexes.CreateOne(indexModel);
            }
            catch
            {
                throw;
            }
        }

        //To Delete all Countries
        public void DeleteAllCountryFormats()
        {
            try
            {
                db.CountryRecord.DeleteManyAsync(_ => true);
            }
            catch
            {
                throw;
            }
        }

        //To load all default countries
        public void LoadDefaultCountryFormats()
        {
            try
            {
                foreach (var item in DefaultData.DefaultCountryList)
                {
                    db.CountryRecord.InsertOne(item);
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion WipeAndLoad

        #region Validation

        // validate postal code format
        public bool PostalCodeValidator(Address address)
        {
            try
            {
                FilterDefinition<CountryFormat> filterCountry = Builders<CountryFormat>.Filter.Eq(x => x.Name, address.Country);

                CountryFormat countryFormat = db.CountryRecord.Find(filterCountry).FirstOrDefault();

                if (countryFormat == null)
                {
                    return true; // if country name is a custom input, then no validation is needed, return true
                }

                if (String.IsNullOrEmpty(address.PostalCode))
                {
                    if (countryFormat.PostalCodeOptional == true)
                    {
                        return true;
                    }
                    return false;
                }

                string pattern = countryFormat.PostalCodePattern;

                if (pattern == null) return true;

                Match m = Regex.Match(address.PostalCode, pattern);

                if (m.Success) return true;

                return false;
            }
            catch
            {
                throw;
            }
        }

        // validate admin area
        public bool AdminAreaValidator(Address address)
        {
            try
            {
                List<String> areaList = GetProvinceList(address.Country);

                if (areaList.Contains(address.AdminArea))
                {
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        #endregion Validation

        #region ParseAddress
        public Address parseAddress(Address address)
        {
            address.AddressLine1 = parseAddressLine(address.AddressLine1);
            address.AddressLine2 = parseAddressLine(address.AddressLine2);
            address.AddressLine3 = parseAddressLine(address.AddressLine3);

            return address;
        }

        private string parseAddressLine(string line)
        {
            if(string.IsNullOrEmpty(line))
            {
                return line;
            }
            line = line.Trim();
            int spaceCount = 0;
            int index = 0;
            char[] result = new char[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    result[index++] = line[i];
                    spaceCount = 0;
                }
                if(line[i] == ' ')
                {
                    if(spaceCount == 0)
                    {
                        result[index++] = line[i];
                        spaceCount = 1;
                    }
                }
            }
            return new string(result, 0, index);
        }

        #endregion ParseAddrress
    }
}
