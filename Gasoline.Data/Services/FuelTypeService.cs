using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Gasoline.Data.EF;
using Gasoline.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gasoline.Data.Services
{
    public class FuelTypeService : ServiceBase, IFuelTypeService
    {
        public FuelTypeService(GasolineContext context) : base(context)
        {
        }

        /// <summary>
        /// Get all FuelTypes
        /// </summary>
        /// <returns>all FuelTypes list</returns>
        public async Task<IEnumerable<FuelType>> BrowseAsync()
        {
            var query = _context.Table<FuelType>();

            var result = await query.ToListAsync();
            return result;
        }

        /// <summary>
        /// Find fuel types that contain given string in name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>fuel types that contain given string in name</returns>
        public async Task<IEnumerable<FuelType>> BrowseByNameAsync(string name)
        {
            var result = await _context.Table<FuelType>().Where(x => x.FuelName.Contains(name)).ToListAsync();

            return result;
        }

        /// <summary>
        /// Find FuelType with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FuelType</returns>
        public async Task<FuelType> GetAsync(Guid id)
        {
            var fuelType = await _context.Table<FuelType>().FirstOrDefaultAsync(x => x.Id == id);

            return fuelType;
        }

        /// <summary>
        /// Add new FuelType
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns></returns>
        public async Task<FuelType> AddAsync(FuelType fuelType)
        {
            fuelType.Id = Guid.NewGuid();

            var result = _context.Add(fuelType).Entity;
            await _context.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// Remove FuelType with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Task> RemoveAsync(Guid id)
        {
            var fuelType = await _context.Table<FuelType>().FirstOrDefaultAsync(x => x.Id == id);

            _context.Remove(fuelType);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}