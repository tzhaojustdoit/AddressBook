using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        AddressService _addressService = new AddressService();

        [HttpGet("index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Address>> Get() =>
            
            _addressService.GetAllAddresses();

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Address> Create([FromBody] Address address)
        {
            _addressService.CreateAddress(address);
            return address;
        }
    }
}