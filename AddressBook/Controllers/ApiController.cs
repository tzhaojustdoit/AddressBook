using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        /// <summary>
        /// Get the list of all addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Address>> Get() =>
            
            _addressService.GetAllAddresses();

        /// <summary>
        /// Add a new address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Address> Create([FromBody] Address address)
        {
            _addressService.CreateAddress(address);
            return address;
        }

        /// <summary>
        /// Add a new country format
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpPost("addcountryformat")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CountryFormat> CreateCountryFormat([FromBody] CountryFormat country)
        {
            _addressService.CreateCountryFormat(country);
            return country;
        }

        /// <summary>
        /// Search an address that matches exactly
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Address> Search([FromBody] Address address)
        {
            var SearchResult = _addressService.GetAddressByWholeAddress(address);
            if(SearchResult.Count == 0)
            {
                return NotFound();
            }
            return SearchResult[0];
        }

        /// <summary>
        /// Search across countries to find addresses
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost("partialsearch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Address>> PartialSearch([FromBody] Address address)
        {
            var SearchResult = _addressService.GetAddressByPartialAddress(address);

            if (SearchResult.Count == 0)
            {
                return NotFound();
            }
            return SearchResult;
        }

        
    }
}