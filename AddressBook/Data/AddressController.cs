using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Data
{
    [Route("api")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        AddressService _addressService = new AddressService();

        [HttpGet]
        public ActionResult<List<Address>> Get() =>
            _addressService.GetAllAddresses();
    }
}