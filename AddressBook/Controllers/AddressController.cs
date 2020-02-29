using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class AddressController : Controller
    {

        AddressService objaddresses = new AddressService();

        [HttpGet]
        [Route("api/AddressBook/Index")]
        public IEnumerable<Address> Index()
        {
            return objaddresses.GetAllAddresses();
        }

        [HttpPost]
        [Route("AddressBook/Create")]
        public void Create([FromBody] Address address)
        {
            objaddresses.AddAddress(address);
        }

        [HttpGet]
        [Route("AddressBook/Details/{id}")]
        public Address Details(string id)
        {
            return objaddresses.GetAddressData(id);
        }

        [HttpPut]
        [Route("AddressBook/Edit")]
        public void Edit([FromBody]Address address)
        {
            objaddresses.UpdateAddress(address);
        }

        [HttpDelete]
        [Route("AddressBook/Delete/{id}")]
        public void Delete(string id)
        {
            objaddresses.DeleteAddress(id);
        }

    }
}