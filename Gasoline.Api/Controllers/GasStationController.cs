using Gasoline.Data.Models;
using Gasoline.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gasoline.Api.Controllers
{
    [Route("api/[controller]")]
    public class GasStationController : ControllerBase
    {
        private readonly GasStationService _gasStationService;

        public GasStationController(GasStationService gasStationService)
        {
            _gasStationService = gasStationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _gasStationService.BrowseAsync();

            return Ok(result);
        }

        [HttpGet("gasStationsFuels")]
        public async Task<IEnumerable<GasStationFuel>> GetGasStationFuelsAsync()
        {
            var r = await _gasStationService.GetGasStationFuels();

            return r;
        }

        [HttpGet("gasStations/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _gasStationService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddGasStation([FromBody] GasStation gasStation)
        {
            var result = await _gasStationService.AddGasStationAsync(gasStation);

            return Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGasStation(Guid id, [FromBody] GasStation gasStation)
        {
            var result = await _gasStationService.UpdateGasStationAsync(id, gasStation);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gasStationService.DeleteGasStation(id);

            return NoContent();
        }


        [HttpPost("{id}/fuels")]
        public async Task<IActionResult> AddFuelToGasStation(Guid id, [FromBody]GasStationFuel gasStationFuel)
        {
            var result = await _gasStationService.AddFuelToGasStation(id, gasStationFuel);

            return Created("", result);
        }

        [HttpPut("{stationId}/fuels/{fueldId}")]
        public async Task<IActionResult> UpdateFuelAtGasStation(Guid stationId, Guid fuelId, [FromBody]GasStationFuel gasStationFuel)
        {
            var result = await _gasStationService.UpdateGasStationFuelAsync(stationId, fuelId, gasStationFuel);

            return Ok(result);
        }

        [HttpDelete("{stationId}/fuels/{fuelId}")]
        public async Task<IActionResult> DeleteFueldFromStation(Guid stationId, Guid fuelId)
        {
            await _gasStationService.DeleteGasStationFuelAsync(stationId, fuelId);

            return NoContent();
        }
    }
}