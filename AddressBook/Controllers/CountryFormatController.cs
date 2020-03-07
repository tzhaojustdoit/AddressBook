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

        #region CRUDi
        /// <summary>
        /// Get the list of country formats
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        [ProducesResponseType(200)]
        public ActionResult<List<CountryFormat>> Get() =>

            _addressService.GetAllCountryFormats();

        /// <summary>
        /// Add country format
        /// </summary>
        /// <param name="countryFormat"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CountryFormat), 200)]
        public ActionResult<CountryFormat> Create([FromBody] CountryFormat countryFormat)
        {
            _addressService.CreateCountryFormat(countryFormat);
            return Ok(countryFormat);
        }

        /// <summary>
        /// Read country format
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryFormat), 200)]
        [ProducesResponseType(404)]
        public ActionResult<CountryFormat> Read(string id)
        {
            CountryFormat res = _addressService.ReadCountryFormat(id);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Update country format
        /// </summary>
        /// <param name="countryFormat"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(CountryFormat), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<CountryFormat> Update([FromBody] CountryFormat countryFormat)
        {
            CountryFormat res = _addressService.ReadCountryFormat(countryFormat.Id);

            if (res == null)
            {
                return NotFound();
            }

            _addressService.UpdateCountryFormat(countryFormat);

            return Ok(countryFormat);
        }

        /// <summary>
        /// Delete country format
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CountryFormat), 200)]
        [ProducesResponseType(404)]
        public ActionResult<CountryFormat> Delete(string id)
        {
            CountryFormat res = _addressService.ReadCountryFormat(id);

            if (res == null)
            {
                return NotFound();
            }

            _addressService.DeleteCountryFormat(id);

            return Ok(res);
        }

        #endregion CRUDi

    }
}