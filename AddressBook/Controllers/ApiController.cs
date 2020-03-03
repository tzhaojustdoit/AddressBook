using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        AddressService _addressService = new AddressService();

        [HttpGet("index")]
        public ActionResult<List<Address>> Get() =>
            
            _addressService.GetAllAddresses();

        [HttpPost("add")]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.CreateAddress(address);

            return NoContent();
        }
    }
}