//using BarberLayered.Models;
//using BusinessLogicLayer.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Serilog;

//namespace BarberLayered.Controllers
//{
//    public class ClientReviewsController : Controller
//    {
//        private readonly IClientService _clientService;
//        private readonly IReviewService _reviewService;
//        private List<BarberLayered.Models.Review> _reviews;
//        private Models.Client? _client;

//        public ClientReviewsController(IClientService clientService, IReviewService reviewService)
//        {
//            _clientService = clientService;
//            _reviewService = reviewService;
//            _client = null;
//            _reviews = new List<Models.Review>();
//        }

//        public async Task<IActionResult> ClientReviews(int clientId)
//        {

//            var reviews = await _reviewService.GetReviews();
//            var clientReviews = reviews.FindAll(review => review.fk_ClientId == clientId);

//            if (!clientReviews.Any()) // No reviews logic for the view
//            {
//                Log.Information("No reviews for the Client with id={Id} was found in the DataBase", clientId);
//            }
//            else
//            {
//                foreach (var review in reviews)
//                {
//                    _reviews.Add(new Review(review));
//                }
//            }

//            ViewBag.Client = _client;
//            ViewBag.Reviews = _reviews;

//            return View(_reviews);
//        }
//        public async Task<IActionResult> DeleteReview(int id)
//        {
//            //await _reviewService.DeleteReview(id);


//            //var result = await _reviewService.DeleteReview(id);
//            //if (result)
//            //{
//            //    Log.Information("Review with id={Id} was successfully deleted", id);
//            //}
//            //else
//            //{
//            //    Log.Error("Failed to delete review with id={Id}", id);
//            //}

//            return RedirectToAction("ClientReviews");
//        }
//    }
//}


using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberLayered.Controllers
{
    public class ClientReviewsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IReviewService _reviewService;
        private List<Review> _reviews;

        public ClientReviewsController(IClientService clientService, IReviewService reviewService)
        {
            _clientService = clientService;
            _reviewService = reviewService;
            _reviews = new List<Models.Review>();
        }

        public async Task<IActionResult> ClientReviews(string clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound();
            }

            //var reviews = await _reviewService.GetReviews();
            //var clientReviews = reviews.FindAll(review => review.fk_ClientId == clientId);

            var clientReviews = await _reviewService.GetReviewsByClientId(clientId);

            if (!clientReviews.Any()) // No reviews logic for the view
            {
                Log.Information("No reviews for the Client with id={Id} was found in the DataBase", clientId);
            }
            else
            {
                foreach (var review in clientReviews)
                {
                    _reviews.Add(new Review(review));
                }
            }

            ViewBag.Client = client;
            ViewBag.Reviews = _reviews;

            return View(_reviews);
        }

        public async Task<IActionResult> DeleteReview(int reviewId, string clientId)
        {
            //var result = await _reviewService.DeleteReview(reviewId);
            //if (result)
            //{
            //    Log.Information("Review with id={reviewId} was successfully deleted", reviewId);
            //}
            //else
            //{
            //    Log.Error("Failed to delete review with id={reviewId}", reviewId);
            //}

            return RedirectToAction("ClientReviews", new { clientId = clientId });
        }
    }
}
