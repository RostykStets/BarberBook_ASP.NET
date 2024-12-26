using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{
    public class BarberInformationController : Controller
    {
        private readonly IBarberService _barberService;
        private readonly IReviewService _reviewService;
        private List<Review> _reviews;
        private Barber? _barber;

        public BarberInformationController(IBarberService barberService, IReviewService reviewService)
        {
            _barberService = barberService;
            _reviewService = reviewService;
            _barber = null;
            _reviews = new List<Review>();
        }

        public async Task<IActionResult> Index(string id)
        {
            var barber = await _barberService.GetBarberById(id);
            if (barber == null)
            {
                Log.Error("No info about Barber with id={Id} was found in the DataBase", id);
            }
            else
            {
                _barber = new Barber(barber);
            }
            
            var reviews = await _reviewService.GetReviewsByBarberId(id);
            if (!reviews.Any()) // No reviews logic for the view
            {
                Log.Information("No reviews for the Barber with id={Id} was found in the DataBase", id);
            }
            else
            {
                foreach (var review in reviews)
                {
                    _reviews.Add(new Review(review));
                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Reviews = _reviews;

            return View();
        }

        public async Task<IActionResult> BarberInformationClient(string id, int clientId)
        {

            var barber = await _barberService.GetBarberById(id);
            if (barber == null)
            {
                Log.Error("No info about Barber with id={Id} was found in the DataBase", id);
            }
            else
            {
                _barber = new Barber(barber);
            }

            var reviews = await _reviewService.GetReviewsByBarberId(id);
            if (!reviews.Any()) // No reviews logic for the view
            {
                Log.Information("No reviews for the Barber with id={Id} was found in the DataBase", id);
            }
            else
            {
                foreach (var review in reviews)
                {
                    _reviews.Add(new Review(review));
                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Reviews = _reviews;

            return View();
        }
    }
}
