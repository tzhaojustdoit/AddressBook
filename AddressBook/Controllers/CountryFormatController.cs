using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AddressBook.Data;
using AddressBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryFormatController : ControllerBase
    {
        AddressService _addressService = new AddressService();

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

    }
}