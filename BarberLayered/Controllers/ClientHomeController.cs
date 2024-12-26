using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberLayered.Controllers
{
    public class ClientHomeController : Controller
    {
        private readonly IBarberShopService _barberShopService;
        private BarberShop? _barberShop;
        private Client? _client;

        public ClientHomeController(IBarberShopService barberShopService)
        {
            _barberShopService = barberShopService;
            _barberShop = null;
            _client = null;
        }
        public async Task<IActionResult> Index(Client client)
        {
            _client = client;

            var barberShop = await _barberShopService.GetBarberShopFirst();

            if (barberShop != null)
                _barberShop = new BarberShop(barberShop);

            ViewBag.Client = _client;

            return View(_barberShop);
        }

        public IActionResult ClientAccount(Client client)
        {
            _client = client;
            ViewBag.Client = _client;
            return View(_client);
        }
    }
}