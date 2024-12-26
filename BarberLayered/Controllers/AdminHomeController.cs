using Microsoft.AspNetCore.Mvc;
using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace BarberLayered.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {
        private readonly IBarberShopService _barberShopService;
        private Admin? _admin;
        private BarberShop? _barberShop;

        public AdminHomeController(IBarberShopService barberShopService)
        {
            _barberShopService = barberShopService;
            _admin = null;
            _barberShop = null;
        }
        public async Task<IActionResult> Index(Admin admin)
        {
            var barberShop = await _barberShopService.GetBarberShopFirst();
            
            if(barberShop != null)
                _barberShop = new BarberShop(barberShop);

            _admin = admin;

            ViewBag.Admin = _admin;

            return View(_barberShop);
        }

        public async Task<IActionResult> AdminAccount(Admin admin)
        {
            _admin = admin;

            return View(_admin);
        }

        public ActionResult AddBarber()
        {
            return View();
        }
    }
}