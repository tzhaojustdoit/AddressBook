using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data.AddressEnum;

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

        // Default Argentina address data
        // Province is not included in the common format
        public static List<CountryFormat> DefaultCountryList = new List<CountryFormat>
        {
            new CountryFormat
            {
                Name = "Argentina",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(ArgentinaProvince))
                .Cast<ArgentinaProvince>()
                .Select(v => v.ToString())
                .ToList(),
                HasAdminArea = false,
            },

            new CountryFormat
            {
                Name = "Australia",
                AdminAreaDisplayName = "State",
                AdminAreas = Enum.GetValues(typeof(AustraliaState))
                .Cast<AustraliaState>()
                .Select(v => v.ToString())
                .ToList(),
                PostalCodePattern = @"\b\d\d\d\d\b",
            },

            new CountryFormat
            {
                Name = "Austria",
                HasAdminArea = false,
            },

            new CountryFormat
            {
                Name = "Belgium",
                HasAdminArea = false,
            },

            new CountryFormat
            {
                Name = "Brazil",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(BrazilProvince))
                .Cast<BrazilProvince>()
                .Select(v => v.ToString())
                .ToList(),
            },

            // new CountryFormat
            // {
            //     Name = "Britain"
            // },

            new CountryFormat
            {
                Name = "Canada",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(CanadaProvince))
                .Cast<CanadaProvince>()
                .Select(v => v.ToString())
                .ToList(),
                PostalCodePattern = @"\b[A-z]\d[A-Z]\s\d[A-Z]\d\b",
            },

            new CountryFormat
            {
                Name = "Channel Islands",
            },

            // use region code outside capital santiago
            // postcode not required
            new CountryFormat
            {
                Name = "Chile",
                AdminAreaDisplayName = "Region",
                AdminAreas = Enum.GetValues(typeof(ChileRegion))
                .Cast<ChileRegion>()
                .Select(v => v.ToString())
                .ToList(),
                PostalCodeOptional = true
            },

            new CountryFormat
            {
                Name = "China",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(ChinaProvince))
                .Cast<ChinaProvince>()
                .Select(v => v.ToString())
                .ToList(),
                PostalCodePattern = "000000",
            },

            new CountryFormat
            {
                Name = "Costa Rica",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(CostaRicaProvince))
                .Cast<CostaRicaProvince>()
                .Select(v => v.ToString())
                .ToList(),
            },

            new CountryFormat
            {
                Name = "Crimea"
            },

            new CountryFormat
            {
                Name = "Czech Republic",
                HasAdminArea = false
            },

            new CountryFormat
            {
                Name = "Denmark",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town"

            },

            new CountryFormat
            {
                Name = "Estonia",
                HasAdminArea = false
            },

            new CountryFormat
            {
                Name = "Fiji",
                HasAdminArea = false
            },

            new CountryFormat
            {
                Name = "Finland",
                HasAdminArea = false
            },

            // new CountryFormat
            // {
            //     Name = "Formosa"
            // },

            new CountryFormat
            {
                Name = "France",
                HasAdminArea = false
            },

            new CountryFormat
            {
                Name = "Germany",
                HasAdminArea = false
            },

            new CountryFormat
            {
                Name = "Great Britain",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town"
            },

            new CountryFormat
            {
                Name = "Greenland",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town"
            },

            new CountryFormat
            {
                Name = "HongKong, China",
                HasAdminArea = false,
                LocalityDisplayName = "District"
            },

            new CountryFormat
            {
                Name = "Taiwan, China",
                HasAdminArea = false,
                LocalityDisplayName = "City"
            },

            new CountryFormat
            {
                Name = "Iceland",
                HasAdminArea = false,
                LocalityDisplayName = "Locality"              
            },

            new CountryFormat
            {
                Name = "India",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town/Locality"   
            },

            new CountryFormat
            {
                Name = "Indonesia",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town/Locality" 
            },

            new CountryFormat
            {
                Name = "Ireland",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town" 
            },

            new CountryFormat
            {
                Name = "Isle of Man",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town"
            },

            new CountryFormat
            {
                Name = "Israel",
                HasAdminArea = false,
                LocalityDisplayName = "City/Town"
            },

            new CountryFormat
            {
                Name = "Italy",
                LocalityDisplayName = "City",
                AdminAreas = Enum.GetValues(typeof(ItalyProvince))
                .Cast<ItalyProvince>()
                .Select(v => v.ToString())
                .ToList(),
                AdminAreaDisplayName = "Province",
                PostalCodePattern = @"\b\d\d\d\d\d\b",
            },

            new CountryFormat
            {
                Name = "Japan",
                AdminAreaDisplayName = "Prefecture",
                AdminAreas = Enum.GetValues(typeof(JapanPrefecture))
                .Cast<JapanPrefecture>()
                .Select(v => v.ToString())
                .ToList(),
                LocalityDisplayName = "City/Village/City ward",
                HasSublocality = true,
                SublocalityDisplayName = "Subarea",
                PostalCodePattern = @"\b\d\d\d-\d\d\d\b",
            },

            new CountryFormat
            {
                Name = "Korea",
                AdminAreaDisplayName = "Province",
                AdminAreas = Enum.GetValues(typeof(KoreaProvince))
                .Cast<KoreaProvince>()
                .Select(v => v.ToString())
                .ToList(),
                HasSublocality = true,
                SublocalityDisplayName = "Subdivision/Precinct",
                PostalCodePattern = @"\b\d\d\d\d\d\b",
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
                AdminAreas = Enum.GetValues(typeof(UsState))
                .Cast<UsState>()
                .Select(v => v.ToString())
                .ToList(),
                PostalCodePattern = @"\b\d\d\d\d\d\b",

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

            new CountryFormat
            {
                Name = "Other"
            },

        };

    }
}
