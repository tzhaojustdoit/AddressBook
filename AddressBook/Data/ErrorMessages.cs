using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    
    public class EmptyCountryError
    {
        public int ErrorCode { get => 100; }

        public string Message { get => "Country input is empty"; }
    }

    public class EmptyAddrLineError
    {
        public int ErrorCode { get => 101; }

        public string Message { get => "Address Line 1 is empty"; }
    }

    public class EmptyAdminAreaError
    {
        public int ErrorCode { get => 102; }

        public string admin { get; set; }

        public string Message { get => "AdminArea is empty"; }
    }

    public class WrongPostalCodeFormat
    {
        public int ErrorCode { get => 103; }

        public string Message { get => "The postal code format is wrong"; }
    }

    public class WrongAdminAreaError
    {
        public int ErrorCode { get => 104; }

        public string Message { get => "The Administrative Area is wrong"; }
    }

}
