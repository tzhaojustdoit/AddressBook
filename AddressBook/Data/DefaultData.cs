using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{


    // Default data
    public static class DefaultData
    {
        private static Random rand = new Random();

        // Default address list
        public static List<Address> GetDefaultAddressList()
        {
            var datalist = new List<Address>();

            for (int i = 0; i < 1000000; i++)
            {
                datalist.Add(GetRandomAddress());
            }

            return datalist;
        }

        private static Address GetRandomAddress()
        {
            Address res = new Address();

            var country = DefaultCountryList[rand.Next(0, DefaultCountryList.Count)];

            res.Country = country.Name;

            res.AddressLine1 = rand.Next(1, 9999).ToString();

            res.AddressLine2 = rand.Next(1, 9999).ToString();

            if (country.HasAddressLine3)
            {
                res.AddressLine3 = rand.Next(1, 9999).ToString();
            }

            if (country.AdminAreas == null)
            {
                res.AdminArea = rand.Next(1, 9999).ToString();
            }
            else
            {
                res.AdminArea = country.AdminAreas[rand.Next(0, country.AdminAreas.Count)];
            }

            if (country.HasLocality)
            {
                res.Locality = rand.Next(1, 9999).ToString();
            }

            if (country.HasSublocality)
            {
                res.Sublocality = rand.Next(1, 9999).ToString();
            }

            if (country.HasExtraData)
            {
                res.ExtraData = rand.Next(1, 9999).ToString();
            }

            return res;
        }

        // Default country list
        public static List<Country> DefaultCountryList = new List<Country>
        {
            new Country
            {
                Name = "Argentina",
            },

            new Country
            {
                Name = "Australia"
            },

            new Country
            {
                Name = "Belgium"
            },

            new Country
            {
                Name = "Brazil"
            },

            new Country
            {
                Name = "Britain"
            },

            new Country
            {
                Name = "Canada"
            },

            new Country
            {
                Name = "Channel Islands"
            },

            new Country
            {
                Name = "Chile"
            },

            new Country
            {
                Name = "China",
                AdminAreaDisplayName = "Province",
                AdminAreas = new List<string>
                {
                    "Liaoning",
                    "Guandong",
                    "Hunan"
                }

            },

            new Country
            {
                Name = "Taiwan"
            },

            new Country
            {
                Name = "Costa Rica",
            },

            new Country
            {
                Name = "Crimea"
            },

            new Country
            {
                Name = "Czech Republic"
            },

            new Country
            {
                Name = "Denmark"
            },

            new Country
            {
                Name = "Estonia"
            },

            new Country
            {
                Name = "Fiji"
            },

            new Country
            {
                Name = "Finland"
            },

            new Country
            {
                Name = "Formosa"
            },

            new Country
            {
                Name = "France"
            },

            new Country
            {
                Name = "Germany"
            },

            new Country
            {
                Name = "Great Britain"
            },

            new Country
            {
                Name = "Greenland"
            },

            new Country
            {
                Name = "Hong Kong"
            },

            new Country
            {
                Name = "Iceland"
            },

            new Country
            {
                Name = "India"
            },

            new Country
            {
                Name = "Indonesia"
            },

            new Country
            {
                Name = "Ireland"
            },

            new Country
            {
                Name = "Isle of Man"
            },

            new Country
            {
                Name = "Israel"
            },

            new Country
            {
                Name = "Italy"
            },

            new Country
            {
                Name = "Japan"
            },

            new Country
            {
                Name = "Korea"
            },

            new Country
            {
                Name = "Latvia"
            },

            new Country
            {
                Name = "Luxembourg"
            },

            new Country
            {
                Name = "Malaysia"
            },

            new Country
            {
                Name = "Mexico"
            },

            new Country
            {
                Name = "Miscellaneous/Other"
            },

            new Country
            {
                Name = "Netherlands"
            },

            new Country
            {
                Name = "New Zealand"
            },

            new Country
            {
                Name = "Northern Ireland"
            },

            new Country
            {
                Name = "Norway"
            },

            new Country
            {
                Name = "Oman"
            },

            new Country
            {
                Name = "Pakistan"
            },

            new Country
            {
                Name = "Poland"
            },

            new Country
            {
                Name = "Portugal"
            },

            new Country
            {
                Name = "Puerto Rico"
            },

            new Country
            {
                Name = "Romania"
            },

            new Country
            {
                Name = "Russia"
            },

            new Country
            {
                Name = "Scotland"
            },

            new Country
            {
                Name = "Singapore"
            },

            new Country
            {
                Name = "South Africa"
            },

            new Country
            {
                Name = "South Korea"
            },

            new Country
            {
                Name = "Spain"
            },

            new Country
            {
                Name = "Sweden"
            },

            new Country
            {
                Name = "Switzerland"
            },

            new Country
            {
                Name = "United Kingdom"
            },

            new Country
            {
                Name = "Ukraine"
            },

            new Country
            {
                Name = "United States",
                AdminAreaDisplayName = "State",
                AdminAreas = new List<string>
                {
                    "Alaska",
                    "Washington",
                    "California"
                }
               
            },

            new Country
            {
                Name = "Uruguay"
            },

            new Country
            {
                Name = "Venezuela"
            },

            new Country
            {
                Name = "Wales"
            },

        };

    }
}
