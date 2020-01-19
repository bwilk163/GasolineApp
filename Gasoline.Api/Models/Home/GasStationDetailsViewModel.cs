using Gasoline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gasoline.Api.Models.Home
{
    public class GasStationDetailsViewModel
    {
        public GasStation   GasStation{ get; set; }
        public IEnumerable<GasStationFuel> GasStationFuels { get; set; }

        public IEnumerable<FuelType> AllFuelTypes { get; set; }

        public float NewPrice { get; set; }
    }
}
