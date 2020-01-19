using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline.Data.Models
{
    /// <summary>
    /// Represents FuelType on GasStation
    /// </summary>
    public class GasStationFuel
    {
        public Guid FuelTypeId { get; set; }
        public virtual FuelType FuelType { get; set; }
        public Guid GasStationId { get; set; }
        public virtual GasStation GasStation { get; set; }

        /// <summary>
        /// Price of fuel on GasStation
        /// </summary>
        public decimal Price { get; set; }
        public DateTime LastUpdateUtc { get; set; }
    }
}