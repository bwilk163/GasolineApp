using System;
using System.Collections;
using System.Collections.Generic;

namespace Gasoline.Data.Models
{
    public class FuelType
    {
        public FuelType(string fuelName)
        {
            this.FuelName = fuelName;
        }
        public FuelType()
        {

        }


        /// <summary>
        /// Auto generated Guid
        /// </summary>
        public Guid Id { get; set; }



        /// <summary>
        /// Fuel name
        /// </summary>
        public string FuelName { get; set; }


        public virtual ICollection<GasStationFuel> GasStationFuels { get; set; }
    }
}
