//using BarberLayered.Models;
//using BusinessLogicLayer.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Serilog;

//namespace BarberLayered.Controllers
//{
//    public class BarberReviewsController : Controller
//    {
//        private readonly IBarberService _barberService;
//        private readonly IReviewService _reviewService;
//        private List<BarberLayered.Models.Review> _reviews;
//        private Models.Barber? _barber;

//        public BarberReviewsController(IBarberService barberService, IReviewService reviewService)
//        {
//            _barberService = barberService;
//            _reviewService = reviewService;
//            _barber = null;
//            _reviews = new List<Models.Review>();
//        }

//        public async Task<IActionResult> BarberReviews(int barberId)
//        {
//            _barber = await _barberService.GetBarberById(barberId);
//            var reviews = await _reviewService.GetReviews();
//            var barberReviews = reviews.FindAll(review => review.fk_BarberId == barberId);

//            if (!barberReviews.Any()) // No reviews logic for the view
//            {
//                Log.Information("No reviews for the Barber with id={Id} was found in the DataBase", barberId);
//            }
//            else
//            {
//                foreach (var review in barberReviews)
//                {
//                    _reviews.Add(new Review(review));
//                }
//            }

//            ViewBag.Barber = _barber;
//            ViewBag.Reviews = _reviews;

//            return View(_reviews);
//        }
//    }
//}





using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{
    public class BarberReviewsController : Controller
    {
        private readonly IBarberService _barberService;
        private readonly IReviewService _reviewService;
        private List<Review> _reviews;
        private Barber? _barber;

        public BarberReviewsController(IBarberService barberService, IReviewService reviewService)
        {
            _barberService = barberService;
            _reviewService = reviewService;
            _barber = null;
            _reviews = new List<Review>();
        }

        public async Task<IActionResult> BarberReviews(string id)
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

            //var reviews = await _reviewService.GetReviews();
            //var barberReviews = reviews.FindAll(review => review.fk_BarberId == id);

            var barberReviews = await _reviewService.GetReviewsByBarberId(id);

            if (!barberReviews.Any()) // No reviews logic for the view
            {
                Log.Information("No reviews for the Barber with id={Id} was found in the DataBase", id);
            }
            else
            {
                foreach (var review in barberReviews)
                {
                    _reviews.Add(new Review(review));
                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Reviews = _reviews;

            return View(_reviews);
        }
    }
}