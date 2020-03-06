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
    public class AddressController : ControllerBase
    {
        AddressService _addressService = new AddressService();

        #region CRUDi
        /// <summary>
        /// Get the list of addresses
        /// </summary>
        /// <returns></returns>
        [HttpGet("index")]
        [ProducesResponseType(200)]
        public ActionResult<List<Address>> Get() =>
            
            _addressService.GetAllAddresses();

        /// <summary>
        /// Add address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Address), 200)]
        [ProducesResponseType(400)]
        public ActionResult<Address> Create([FromBody] Address address)
        {
            // validation
            // todo

            _addressService.CreateAddress(address);
            return Ok(address);
        }

        /// <summary>
        /// Read address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Address), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Address> Read(string id)
        {
            Address res = _addressService.ReadAddress(id);

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
        /// Update address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Address), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Address> Update([FromBody] Address address)
        {
            Address addr = _addressService.ReadAddress(address.Id);

            if (addr == null)
            {
                return NotFound();
            }

            // validation
            // todo

            _addressService.UpdateAddress(address);

            return Ok(address);
        }

        /// <summary>
        /// Delete address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Address), 200)]
        [ProducesResponseType(404)]
        public ActionResult<Address> Delete(string id)
        {
            Address addr = _addressService.ReadAddress(id);

            if (addr == null)
            {
                return NotFound();
            }

            _addressService.DeleteAddress(id);

            return Ok();
        }

        #endregion CRUDi

        #region Search
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

        #endregion Search
    }
}