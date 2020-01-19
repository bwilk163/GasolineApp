using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gasoline.Api.Models.Home;
using Gasoline.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gasoline.Api.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IGasStationService _gasStationService;
        private readonly IFuelTypeService _fuelTypeService;
        public HomeController(IGasStationService gasStationService, IFuelTypeService fuelTypeService)
        {
            _gasStationService = gasStationService;
            _fuelTypeService = fuelTypeService;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("allStations")]
        public async Task<IActionResult> AllStationsView()
        {
            var stations = await _gasStationService.BrowseAsync();
            return View(stations);
        }

        [Route("addStation")]
        public IActionResult AddGasStationView()
        {
            return View();
        }

        [Route("addGasStation")]
        public async Task<IActionResult> AddGasStation(AddGasStationViewModel addGasStationViewModel)
        {
            if (ModelState.IsValid)
            {
                var x = await _gasStationService.AddGasStationAsync(
                  new Data.Models.GasStation
                  {
                      City = addGasStationViewModel.City,
                      Name = addGasStationViewModel.Name,
                      PostalCode = addGasStationViewModel.PostalCode,
                      Street = addGasStationViewModel.Street
                  });
                return RedirectToAction("GasStationView", new { id = x.Id });
            }
            else
                return RedirectToAction("AddGasStationView");
        }

        [Route("deleteGasStation")]
        public async Task<IActionResult> DeleteGasStation(Guid id)
        {
            await _gasStationService.DeleteGasStation(id);

            return RedirectToAction("AllStationsView");
        }

        [Route("station/{id}")]
        public async Task<IActionResult> GasStationView(Guid id)
        {
            var x = await _gasStationService.GetByIdAsync(id);
            var fuels = await _gasStationService.GetGasStationFuelsByGasStationId(id);
            var allFuels = await _fuelTypeService.BrowseAsync();

            var model = new GasStationDetailsViewModel
            {
                GasStation = x,
                GasStationFuels = fuels,
                AllFuelTypes = allFuels
            };

            return View(model);
        }

        [Route("station/updateprice")]
        public async Task<IActionResult> UpdatePrice(decimal NewPrice, Guid FuelTypeId, Guid GasStationId)
        {
            var x = await _gasStationService.UpdateGasStationFuelAsync(GasStationId, FuelTypeId,
                 new Data.Models.GasStationFuel
                 {
                     Price = NewPrice
                 });
            return RedirectToAction("GasStationView", new { id = GasStationId });
        }

        [Route("station/addfuel")]
        public async Task<IActionResult> AddFuelToGasStation(Guid FuelTypeId, Guid GasStationId)
        {
            var x = await _gasStationService.AddFuelToGasStation(
                GasStationId,
                new Data.Models.GasStationFuel
                {
                    FuelTypeId = FuelTypeId
                });

            return RedirectToAction("GasStationView", new { id = GasStationId });
        }
        

        [Route("cheapestFuels/{id}")]
        public async Task<IActionResult> CheapestFuelByIdView(Guid id)
        {
            var gasStationFuels = await _gasStationService.CheapestFuelById(id);
            if (gasStationFuels != null)
            {
                List<GasStationFuelViewModel> gasStationFuelsViewModel = new List<GasStationFuelViewModel>();

                foreach (var gasStationFuel in gasStationFuels)
                {
                    var gasStation = await _gasStationService.GetByIdAsync(gasStationFuel.GasStationId);
                    var fuel = await _fuelTypeService.GetAsync(gasStationFuel.FuelTypeId);

                    GasStationFuelViewModel gasStationFuelViewModel =
                        new GasStationFuelViewModel
                        {
                            FuelName = fuel.FuelName,
                            GasStationName = gasStation.Name,
                            FuelPrice = gasStationFuel.Price
                        };
                    gasStationFuelsViewModel.Add(gasStationFuelViewModel);
                }
                return View(gasStationFuelsViewModel);
            }
            else
                return View(null);
        }

        [Route("fuels")]
        public async Task<IActionResult> AllFuelsView()
        {
            var fuels =  await _fuelTypeService.BrowseAsync();

            return View(fuels);
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="FuelTypeId"></param>
        /// <param name="GasStationId"></param>
        /// <returns></returns>
        [Route("deletefueltypefromgasstation")]
        public async Task<IActionResult> DeleteFuelTypeFromGasStation(Guid FuelTypeId, Guid GasStationId)
        {
            await _gasStationService.DeleteGasStationFuelAsync(GasStationId, FuelTypeId);

            return RedirectToAction("GasStationView", new { id = GasStationId });
        }
    }
}