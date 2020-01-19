using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Gasoline.Data.Services;
using Gasoline.Data.Models;

namespace Gasoline.Api.Controllers
{
    [Route("api/[controller]")]
    public class FuelTypesController : ControllerBase
    {
        private readonly FuelTypeService _fuelTypeService;

        public FuelTypesController(FuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }


        /// <summary>
        /// Get all FuelTypes
        /// </summary>
        /// <returns>All FuelTypes</returns>
        [HttpGet]
        public async Task<IActionResult> BrowseAsync()
        {
            var result = await _fuelTypeService.BrowseAsync();

            // return OK status code and all FuelTypes
            return Ok(result);
        }

        /// <summary>
        /// Get FuelTypes that contain given string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>FuelTypes</returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await _fuelTypeService.BrowseByNameAsync(name);

            // return OK status code and all FuelTypes that contain given string in name
            return Ok(result);
        }

        /// <summary>
        /// Add new FuelType
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns>Status code and added FuelType</returns>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]FuelType fuelType)
        {
            var result = await _fuelTypeService.AddAsync(fuelType);

            return Created("", result);
        }


        /// <summary>
        /// Delete FuelType with given guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            await _fuelTypeService.RemoveAsync(id);

            return NoContent();
        }
    }
}