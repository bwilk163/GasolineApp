using Gasoline.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gasoline.Data.Services
{
    public interface IGasStationService
    {
        /// <summary>
        /// Get all GasStations
        /// </summary>
        /// <returns>GasStation with fuels available</returns>
        Task<IEnumerable<GasStation>> BrowseAsync();

        /// <summary>
        /// Get all GasStations with FuelTypes available there
        /// </summary>
        /// <returns>GasStations with FuelTypes</returns>
        Task<IEnumerable<GasStationFuel>> GetGasStationFuels();

        Task<IEnumerable<GasStationFuel>> GetGasStationFuelsByGasStationId(Guid id);

        /// <summary>
        /// Get GasStation with FuelTypes by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GasStation with FuelTypes</returns>
        Task<GasStation> GetByIdAsync(Guid id);

        /// <summary>
        /// Add new GasStation
        /// </summary>
        /// <param name="gasStation"></param>
        /// <returns></returns>
        Task<GasStation> AddGasStationAsync(GasStation gasStation);

        /// <summary>
        /// Add GasStationFuel to GasStation
        /// </summary>
        /// <param name="stationId">GasStation Guid</param>
        /// <param name="gasStationFuel"></param>
        /// <returns></returns>
        Task<GasStationFuel> AddFuelToGasStation(Guid stationId, GasStationFuel gasStationFuel);

        /// <summary>
        /// Update GasStation, for example address or name
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="gasStation"></param>
        /// <returns></returns>
        Task<GasStation> UpdateGasStationAsync(Guid guid, GasStation gasStation);

        /// <summary>
        /// Delete GasStation with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteGasStation(Guid id);

        /// <summary>
        /// Update GasStationFuel price
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="fuelTypeId"></param>
        /// <param name="gasStationFuel"></param>
        /// <returns></returns>
        Task<GasStationFuel> UpdateGasStationFuelAsync(Guid stationId, Guid fuelTypeId, GasStationFuel gasStationFuel);

        /// <summary>
        /// Remove FuelType from given GasStation
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="fuelTypeId"></param>
        /// <returns></returns>
        Task DeleteGasStationFuelAsync(Guid stationId, Guid fuelTypeId);

        /// <summary>
        /// Gets sorted fuels
        /// </summary>
        /// <param name="id">Fuel id</param>
        /// <returns>List with fuels sorted by price</returns>
        Task<List<GasStationFuel>> CheapestFuelById(Guid id);
    }
}