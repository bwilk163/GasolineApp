using Gasoline.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gasoline.Data.Services
{
    public interface IFuelTypeService
    {
        /// <summary>
        /// Get all FuelTypes
        /// </summary>
        /// <returns>all FuelTypes list</returns>
        Task<IEnumerable<FuelType>> BrowseAsync();

        /// <summary>
        /// Find fuel types that contain given string in name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>fuel types that contain given string in name</returns>
        Task<IEnumerable<FuelType>> BrowseByNameAsync(string name);

        /// <summary>
        /// Find FuelType with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>FuelType</returns>
        Task<FuelType> GetAsync(Guid id);

        /// <summary>
        /// Add new FuelType
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns></returns>
        Task<FuelType> AddAsync(FuelType fuelType);

        /// <summary>
        /// Remove FuelType with given Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Task> RemoveAsync(Guid id);
    }
}
