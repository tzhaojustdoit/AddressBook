using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Data
{
    /// <summary>
    /// Recently added addresses
    /// </summary>
    public static class RecentlyAddedAddresses
    {
        // the list
        public static LinkedList<Address> RecentlyAddedAddressList { get; set; } = new LinkedList<Address>();
    }
}
