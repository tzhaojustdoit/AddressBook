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
        public static List<CountryFormat> DefaultCountryList = new List<CountryFormat>
        {
            new CountryFormat
            {
                Name = "Argentina",
                AdminAreaDisplayName = "Province",
                AdminAreas = new List<string>
                {
                    "BA",
                    "CA",
                    "CB",
                    "CC",
                    "CH",
                    "CN",
                    "CT",
                    "ER",
                    "FM",
                    "JY",
                    "LP",
                    "LR",
                    "MN",
                    "MZ",
                    "NQ",
                    "RN",
                    "SA",
                    "SC",
                    "SE",
                    "SF",
                    "SJ",
                    "SL",
                    "TF",
                    "TM"
                }
            },

            new CountryFormat
            {
                Name = "Australia"
            },

            new CountryFormat
            {
                Name = "Belgium"
            },

            new CountryFormat
            {
                Name = "Brazil"
            },

            new CountryFormat
            {
                Name = "Britain"
            },

            new CountryFormat
            {
                Name = "Canada"
            },

            new CountryFormat
            {
                Name = "Channel Islands"
            },

            new CountryFormat
            {
                Name = "Chile"
            },

            new CountryFormat
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

            new CountryFormat
            {
                Name = "Costa Rica",
            },

            new CountryFormat
            {
                Name = "Crimea"
            },

            new CountryFormat
            {
                Name = "Czech Republic"
            },

            new CountryFormat
            {
                Name = "Denmark"
            },

            new CountryFormat
            {
                Name = "Estonia"
            },

            new CountryFormat
            {
                Name = "Fiji"
            },

            new CountryFormat
            {
                Name = "Finland"
            },

            new CountryFormat
            {
                Name = "Formosa"
            },

            new CountryFormat
            {
                Name = "France"
            },

            new CountryFormat
            {
                Name = "Germany"
            },

            new CountryFormat
            {
                Name = "Great Britain"
            },

            new CountryFormat
            {
                Name = "Greenland"
            },

            new CountryFormat
            {
                Name = "Iceland"
            },

            new CountryFormat
            {
                Name = "India"
            },

            new CountryFormat
            {
                Name = "Indonesia"
            },

            new CountryFormat
            {
                Name = "Ireland"
            },

            new CountryFormat
            {
                Name = "Isle of Man"
            },

            new CountryFormat
            {
                Name = "Israel"
            },

            new CountryFormat
            {
                Name = "Italy"
            },

            new CountryFormat
            {
                Name = "Japan"
            },

            new CountryFormat
            {
                Name = "Korea"
            },

            new CountryFormat
            {
                Name = "Latvia"
            },

            new CountryFormat
            {
                Name = "Luxembourg"
            },

            new CountryFormat
            {
                Name = "Malaysia"
            },

            new CountryFormat
            {
                Name = "Mexico"
            },

            new CountryFormat
            {
                Name = "Miscellaneous/Other"
            },

            new CountryFormat
            {
                Name = "Netherlands"
            },

            new CountryFormat
            {
                Name = "New Zealand"
            },

            new CountryFormat
            {
                Name = "Northern Ireland"
            },

            new CountryFormat
            {
                Name = "Norway"
            },

            new CountryFormat
            {
                Name = "Oman"
            },

            new CountryFormat
            {
                Name = "Pakistan"
            },

            new CountryFormat
            {
                Name = "Poland"
            },

            new CountryFormat
            {
                Name = "Portugal"
            },

            new CountryFormat
            {
                Name = "Puerto Rico"
            },

            new CountryFormat
            {
                Name = "Romania"
            },

            new CountryFormat
            {
                Name = "Russia"
            },

            new CountryFormat
            {
                Name = "Scotland"
            },

            new CountryFormat
            {
                Name = "Singapore"
            },

            new CountryFormat
            {
                Name = "South Africa"
            },

            new CountryFormat
            {
                Name = "South Korea"
            },

            new CountryFormat
            {
                Name = "Spain"
            },

            new CountryFormat
            {
                Name = "Sweden"
            },

            new CountryFormat
            {
                Name = "Switzerland"
            },

            new CountryFormat
            {
                Name = "United Kingdom"
            },

            new CountryFormat
            {
                Name = "Ukraine"
            },

            new CountryFormat
            {
                Name = "United States",
                AdminAreaDisplayName = "State",
                AdminAreas = new List<string>
                {
                    "AL",
                    "AK",
                    "AZ",
                    "AR",
                    "CA",
                    "CO",
                    "CT",
                    "DE",
                    "FL",
                    "GA",
                    "HI",
                    "ID",
                    "IL",
                    "IN",
                    "IA",
                    "KS",
                    "KY",
                    "LA",
                    "ME",
                    "MD",
                    "MA",
                    "MI",
                    "MN",
                    "MS",
                    "MO",
                    "MT",
                    "NE",
                    "NV",
                    "NH",
                    "NJ",
                    "NM",
                    "NY",
                    "NC",
                    "ND",
                    "OH",
                    "OK",
                    "OR",
                    "PA",
                    "RI",
                    "SC",
                    "SD",
                    "TN",
                    "TX",
                    "UT",
                    "VT",
                    "VA",
                    "WA",
                    "WV",
                    "WI",
                    "WY"
                }
               
            },

            new CountryFormat
            {
                Name = "Uruguay"
            },

            new CountryFormat
            {
                Name = "Venezuela"
            },

            new CountryFormat
            {
                Name = "Wales"
            },

        };

    }
}
