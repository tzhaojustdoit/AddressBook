using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    
    public class EmptyCountryErrror
    {
        public int ErrorCode { get => 100; }

        public string Message { get => "Country input is empty"; }
    }

    public class EmptyAddrLineErrror
    {
        public int ErrorCode { get => 100; }

        public string Message { get => "Address Line 1 is empty"; }
    }

    public class EmptyAdminAreaErrror
    {
        public int ErrorCode { get => 100; }

        public string admin { get; set; }

        public string Message { get => admin + " is empty"; }
    }

}
