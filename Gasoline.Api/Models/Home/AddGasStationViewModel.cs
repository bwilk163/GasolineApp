using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gasoline.Api.Models.Home
{
    public class AddGasStationViewModel
    {
        /// <summary>
        /// Name of the GasStation
        /// </summary>
        /// 
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// GasStation's city
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// GasStation's street
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// GasStation city's postal code
        /// </summary>
        [Required]
        public string PostalCode { get; set; }
    }
}
