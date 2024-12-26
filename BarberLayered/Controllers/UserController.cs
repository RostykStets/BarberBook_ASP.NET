using Microsoft.AspNetCore.Mvc;

namespace BarberLayered.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
