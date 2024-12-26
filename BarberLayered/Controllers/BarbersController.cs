using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{
    public class BarbersController : Controller
    {
        private List<Barber> _barbers;
        private readonly IBarberService _barberService;

        public BarbersController(IBarberService barberService)
        {
            _barberService = barberService;
            _barbers = new List<Barber>();
        }

        public async Task<IActionResult> Index()
        {
            var barbers = await _barberService.GetBarbers();
            if (!barbers.Any()) // No barbers in DB
            {
                Log.Error("No Barbers in DataBase");
            }
            else
            {
                _barbers = new List<Barber>();
                foreach (var barber in barbers)
                {
                    _barbers.Add(new Barber(barber));
                }
            }

            string infoPath = "Index";
            string servicePath = "Index";

            ViewData["infoPath"] = infoPath;
            ViewData["servicePath"] = servicePath;

            return View(_barbers);
        }

        public async Task<IActionResult> ClientBarbers(string clientId)
        {
            var barbers = await _barberService.GetBarbers();
            if (!barbers.Any()) // No barbers in DB
            {
                Log.Error("No Barbers in DataBase");
            }
            else
            {
                _barbers = new List<Barber>();
                foreach (var barber in barbers)
                {
                    _barbers.Add(new Barber(barber));
                }
            }

            string infoPath = "BarberInformationClient";
            string servicePath = "BarberServiceClient";

            ViewBag.Barbers = _barbers;
            ViewData["infoPath"] = infoPath;
            ViewData["servicePath"] = servicePath;

            return View(_barbers);
        }
    }
}
