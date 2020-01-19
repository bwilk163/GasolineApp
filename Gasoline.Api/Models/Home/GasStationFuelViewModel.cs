using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gasoline.Api.Models.Home
{
    public class GasStationFuelViewModel
    {
        public string GasStationName { get; set; }
        public string FuelName { get; set; }
        public decimal FuelPrice { get; set; }
    }
}
