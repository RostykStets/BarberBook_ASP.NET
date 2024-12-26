using BarberLayered.Models;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{
    [Authorize(Roles = "Barber")]
    public class BarberHomeController : Controller
    {
        private readonly IBarberHomeService _barberHomeService;
        private Models.Barber? _barber;
        private readonly List<Visit> _visits;

        public BarberHomeController(IBarberHomeService barberHomeService)
        {
            _barberHomeService = barberHomeService;
            _barber = null;
            _visits = new List<Visit>();
        }

        public async Task<IActionResult> Index(Barber barber)
        {
            _barber = barber;

            var visits = await _barberHomeService.GetVisitsByBarberId(_barber.Id);
            if (!visits.Any())
            {
                Log.Error("No visits for barber id={Id} in DataBase", _barber.Id);
            }
            else
            {
                foreach (var visit in visits)
                {
                    _visits.Add(new Visit(visit));
                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Visits = _visits;

            return View(_barber);
        }

        public IActionResult EditProfile(Barber barber)
        {
            _barber = barber;
            ViewBag.Barber = _barber;
            return View(_barber);
        }

        //[HttpPost]
        //public IActionResult EditProfile(Barber barber)
        //{
        //    _barber.Name = barber.Name;
        //    _barber.Surname = barber.Surname;
        //    _barber.Phone = barber.Phone;
        //    _barber.Email = barber.Email;
        //    _barber.Description = barber.Description;
        //    _barber.PhotoUri = barber.PhotoUri;
        //    _barber.PortfolioUri = barber.PortfolioUri;

        //    return Redirect("/BarberHome/Index");
        //}
    }
}