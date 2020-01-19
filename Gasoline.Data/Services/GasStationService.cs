using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gasoline.Data.EF;
using Gasoline.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gasoline.Data.Services
{
    public class GasStationService : ServiceBase, IGasStationService
    {
        public GasStationService(GasolineContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all GasStations
        /// </summary>
        /// <returns>GasStation with fuels available</returns>
        public async Task<IEnumerable<GasStation>> BrowseAsync()
        {
            var stations = _context.Table<GasStation>().AsQueryable();
            var fuels = _context.Table<GasStationFuel>().ToList();

            var result = await stations.ToListAsync();
            return result;
        }


        /// <summary>
        /// Get all GasStations with FuelTypes available there
        /// </summary>
        /// <returns>GasStations with FuelTypes</returns>
        public async Task<IEnumerable<GasStationFuel>> GetGasStationFuels()
        {
            var result = await _context.Table<GasStationFuel>()
                .Include(x => x.FuelType)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<GasStationFuel>> GetGasStationFuelsByGasStationId(Guid id)
        {
            var result = await _context.Table<GasStationFuel>()
                .Where(x => x.GasStationId == id)
                .Include(x => x.FuelType)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// Get GasStation with FuelTypes by Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GasStation with FuelTypes</returns>
        public async Task<GasStation> GetByIdAsync(Guid id)
        {
            var result = await _context.Table<GasStation>()
                .Include(x => x.GasStationFuels)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        /// <summary>
        /// Add new GasStation
        /// </summary>
        /// <param name="gasStation"></param>
        /// <returns></returns>
        public async Task<GasStation> AddGasStationAsync(GasStation gasStation)
        {
            await _context.AddAsync(gasStation);
            await _context.SaveChangesAsync();

            return gasStation;
        }


        /// <summary>
        /// Add GasStationFuel to GasStation
        /// </summary>
        /// <param name="stationId">GasStation Guid</param>
        /// <param name="gasStationFuel"></param>
        /// <returns></returns>
        public async Task<GasStationFuel> AddFuelToGasStation(Guid stationId, GasStationFuel gasStationFuel)
        {
            gasStationFuel.GasStationId = stationId;
            gasStationFuel.LastUpdateUtc = DateTime.Now;

            await _context.AddAsync(gasStationFuel);
            await _context.SaveChangesAsync();

            return gasStationFuel;
        }

        /// <summary>
        /// Update GasStation, for example address or name
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="gasStation"></param>
        /// <returns></returns>
        public async Task<GasStation> UpdateGasStationAsync(Guid guid, GasStation gasStation)
        {
            GasStation _gasStation = await _context.Table<GasStation>().FirstOrDefaultAsync(x => x.Id == guid);

            _gasStation.City = gasStation.City;
            _gasStation.Street = gasStation.Street;
            _gasStation.PostalCode = gasStation.PostalCode;
            _gasStation.Name = gasStation.Name;

            _context.Update(_gasStation);

            await _context.SaveChangesAsync();

            return gasStation;
        }


        /// <summary>
        /// Delete GasStation with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteGasStation(Guid id)
        {
            var gasStation = await _context.Table<GasStation>().FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(gasStation);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update GasStationFuel price
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="fuelTypeId"></param>
        /// <param name="gasStationFuel"></param>
        /// <returns></returns>
        public async Task<GasStationFuel> UpdateGasStationFuelAsync(Guid stationId, Guid fuelTypeId, GasStationFuel gasStationFuel)
        {
            //Find FuelType on GasStation
            GasStationFuel _gasStationFuel = await _context.Table<GasStationFuel>().FirstOrDefaultAsync(x => x.GasStationId == stationId && x.FuelTypeId == fuelTypeId);

            //Update Fuel price on GasStation
            _gasStationFuel.Price = gasStationFuel.Price;
            _gasStationFuel.LastUpdateUtc = DateTime.UtcNow;

            //Update in table
            _context.Update(_gasStationFuel);

            await _context.SaveChangesAsync();

            return gasStationFuel;
        }

        /// <summary>
        /// Remove FuelType from given GasStation
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="fuelTypeId"></param>
        /// <returns></returns>
        public async Task DeleteGasStationFuelAsync(Guid stationId, Guid fuelTypeId)
        {
            var gasStationFuel = await _context.Table<GasStationFuel>().FirstOrDefaultAsync(x => x.GasStationId == stationId && x.FuelTypeId == fuelTypeId);

            _context.Remove(gasStationFuel);

            await _context.SaveChangesAsync();
        }

        public async Task<List<GasStationFuel>> CheapestFuelById(Guid id)
        {
            var fuels = await _context.Table<GasStationFuel>().Where(x => x.FuelTypeId == id).OrderBy(x => x.Price).ToListAsync();

            if (fuels.Count > 0)
                return fuels;
            else
                return null;
        }
    }
}