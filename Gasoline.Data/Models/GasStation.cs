using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline.Data.Models
{
    public class GasStation
    {
        /// <summary>
        /// Auto generated GasStation Guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the GasStation
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GasStation's city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// GasStation's street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// GasStation city's postal code
        /// </summary>
        public string PostalCode { get; set; }


        /// <summary>
        /// Fuels available on the GasStation
        /// </summary>
        public virtual ICollection<GasStationFuel> GasStationFuels { get; set; } 
    }
}