using BarberLayered.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using BusinessLogicLayer.Services.Interfaces;

namespace BarberLayered.Controllers
{
    public class BarberShopController : Controller
    {
        private readonly IBarberShopService _barberShopService;
        private BarberShop? _barberShop;

        public BarberShopController(IBarberShopService barberShopService)
        {
            _barberShopService = barberShopService;
            _barberShop = null;
        }

        public async Task<IActionResult> Index()
        {
            var barberShop = await _barberShopService.GetBarberShopFirst();
            if (barberShop == null)
            {
                Log.Error("No info about BarberShop in DataBase");
            }
            else
            {
                _barberShop = new BarberShop(barberShop);
            }

            string path = "/Barbers/Index";

            ViewData["Path"] = path;

            return View(_barberShop);
        }
    }
}