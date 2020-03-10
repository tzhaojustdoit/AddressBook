using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AddressBook.Data.AddressEnum;
using System.Text.RegularExpressions;
namespace AddressBook.Data
{


    // Default data
    public static class DefaultData
    {
        private static Random rand = new Random();
        //check if the string is numeric
        private static readonly Regex regex = new Regex(@"^\d+$");
        //file path
        private static readonly string[] fileLocation = {"\\Dataset\\USNYSTATE.txt",
                                                        "\\Dataset\\USSF.txt",
                                                        "\\Dataset\\USMASTATE.txt",
                                                        "\\Dataset\\Australia.txt",
                                                        "\\Dataset\\CAMEDICINEHAT.txt",
                                                        "\\Dataset\\CAFREDERICTON.txt",
                                                        "\\Dataset\\NewYorkCity.txt"
                                                        };
        // Default address list
        public static List<Address> GetDefaultAddressList()
        {
            var datalist = new List<Address>();
            int counter = 0;
            string line;

            string startupPath = Environment.CurrentDirectory;

            //read US New York State address
            StreamReader file = new StreamReader(@startupPath + fileLocation[0]);
            while((line = file.ReadLine()) != null)
            {
                counter++;
                // //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "United States";
                address.AdminArea = "NY";
                address.Locality = tempLine[5];
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                if(!String.IsNullOrEmpty(tempLine[4]))
                {
                    if(regex.IsMatch(tempLine[4])) address.AddressLine2 = "Apartment " + tempLine[4];
                    else address.AddressLine2 = tempLine[4];
                }
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                
                datalist.Add(address);
            }
            file.Close();

            //read US California address
            file = new System.IO.StreamReader(@startupPath + fileLocation[1]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "United States";
                address.AdminArea = "CA";
                address.Locality = "San Francisco";
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4]))
                {
                    if(regex.IsMatch(tempLine[4])) address.AddressLine2 = "Apartment " + tempLine[4];
                    else address.AddressLine2 = tempLine[4];
                }
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();

            //read US MA State address
            file = new System.IO.StreamReader(@startupPath + fileLocation[2]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "United States";
                address.AdminArea = "MA";
                address.Locality = tempLine[5];
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4]))
                {
                    if(regex.IsMatch(tempLine[4])) address.AddressLine2 = "Apartment " + tempLine[4];
                    else address.AddressLine2 = tempLine[4];
                }
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();

            //read AU addresses
            file = new System.IO.StreamReader(@startupPath + fileLocation[3]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "Australia";
                address.AdminArea = tempLine[7];
                address.Locality = tempLine[5];
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4])) address.AddressLine2 = tempLine[4];
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();

            //add canada medicine hat address
            file = new System.IO.StreamReader(@startupPath + fileLocation[4]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "Canada";
                address.AdminArea = "AB";
                address.Locality = "Medicine Hat";
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4]) && tempLine[4].Length > 0) address.AddressLine2 = "Unit " + tempLine[4];
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();

            //add canada fredericton address
            file = new System.IO.StreamReader(@startupPath + fileLocation[5]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "Canada";
                address.AdminArea = "NB";
                address.Locality = tempLine[5];
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4]) && tempLine[4].Length > 0) address.AddressLine2 = "Unit " + tempLine[4];
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();

            //read US New York City address
            file = new System.IO.StreamReader(@startupPath + fileLocation[6]);
            counter = 0;
            while((line = file.ReadLine()) != null)
            {
                counter++;
                //skip first line
                if(counter == 1) continue;
                var tempLine = line.Split('\t');
                //if the line format is invalid, skip
                if(tempLine.Length < 8) continue;
                Address address = new Address();
                address.Country = "United States";
                address.AdminArea = "NY";
                address.Locality = "New York City";
                address.AddressLine1 = tempLine[2] + " " + tempLine[3];
                address.PostalCode = tempLine[8];
                if(!String.IsNullOrEmpty(tempLine[4]))
                {
                    if(regex.IsMatch(tempLine[4])) address.AddressLine2 = "Apartment " + tempLine[4];
                    else address.AddressLine2 = tempLine[4];
                }
                if(!String.IsNullOrEmpty(address.AddressLine2))
                {
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.AddressLine2, address.PostalCode);
                }else{
                    address.HashCode = HashCode.Combine(address.Country, address.AdminArea, address.Locality, address.AddressLine1, address.PostalCode);
                }
                datalist.Add(address);
            }
            file.Close();
            return datalist;
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
                Name = "Latvia",
                HasAdminArea = false,
                LocalityDisplayName = "City" 
            },

            new CountryFormat
            {
                Name = "Luxembourg",
                HasAdminArea = false,
                LocalityDisplayName = "City/Locality" 
            },

            new CountryFormat
            {
                Name = "Malaysia",
                AdminAreaDisplayName = "State",
                AdminAreas = Enum.GetValues(typeof(MalaysiaState))
                .Cast<MalaysiaState>()
                .Select(v => v.ToString())
                .ToList()
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

    // private static string HashAddresses(string entireAddress)
    // {
        
    // }
}
