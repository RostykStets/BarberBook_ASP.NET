using BarberLayered.Models;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;


namespace BarberLayered.Controllers
{
    public class BarberServiceController : Controller
    {
        private List<Service> _services;
        private Barber? _barber;
        private readonly IServiceService _serviceService;
        private readonly IBarberService _barberService;


        public BarberServiceController(IServiceService serviceService, IBarberService barberService)
        {
            _serviceService = serviceService;
            _barberService = barberService;
            _barber = null;
            _services = new List<Service>();
        }

        public async Task<IActionResult> Index(string id)
        {
            var barber = await _barberService.GetBarberById(id);
            if (barber == null) 
            {
                Log.Error("No Barber with id={Id} information in DataBase", id);
            }
            else
            {
                _barber = new Barber(barber);
            }
            
            var services = await _serviceService.GetServicesByBarberId(id);
            if (!services.Any()) // No services for this barber
            {
                Log.Error("No Services for Barber with id={Id} was found in DataBase", id);
            }
            else
            {
                _services = new List<Service>();
                foreach (var service in services)
                {
                    _services.Add(new Service(service));

                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Services = _services;

            string Path = "Index";

            ViewData["Path"] = Path;

            return View();
        }

        public async Task<IActionResult> BarberServiceClient(string id)
        {
            var barber = await _barberService.GetBarberById(id);
            if (barber == null)
            {
                Log.Error("No Barber with id={Id} information in DataBase", id);
            }
            else
            {
                _barber = new Barber(barber);
            }

            var services = await _serviceService.GetServicesByBarberId(id);
            if (!services.Any()) // No services for this barber
            {
                Log.Error("No Services for Barber with id={Id} was found in DataBase", id);
            }
            else
            {
                _services = new List<Service>();
                foreach (var service in services)
                {
                    _services.Add(new Service(service));

                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Services = _services;

            string Path = "ServiceAppointmentClient";

            ViewData["Path"] = Path;

            return View();
        }

        public async Task<IActionResult> Add(string id)
        {
            var barber = await _barberService.GetBarberById(id);
            if (barber == null)
            {
                Log.Error("No Barber with id={Id} information in DataBase", id);
            }
            else
            {
                _barber = new Barber(barber);
            }
            var services = await _serviceService.GetServicesByBarberId(id);
            if (!services.Any()) // No services for this barber
            {
                Log.Error("No Services for Barber with id={Id} was found in DataBase", id);
            }
            else
            {
                _services = new List<Service>();
                foreach (var service in services)
                {
                    _services.Add(new Service(service));
                    
                }
            }

            ViewBag.Barber = _barber;
            ViewBag.Services = _services;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetServices(string id)
        {

            var services = await _serviceService.GetServicesByBarberId(id);
            if (!services.Any()) // No services for this barber
            {
                Log.Error("No Services for Barber with id={Id} was found in DataBase", id);
            }
            else
            {
                _services = new List<Service>();
                foreach (var service in services)
                {
                    _services.Add(new Service(service));
                }
            }
            var barberServices = _services;
            Console.WriteLine(id);
            return Json(new { barberServices });
        }

        [HttpPost]
        public IActionResult SubmitAppointment(AppointmentViewModel model)
        {
            System.Console.WriteLine("AppointmentViewModel:");
            System.Console.WriteLine(model.Name + " " + model.Phone + " " + model.SelectedDay + " " + model.SelectedTime + " " + model.SelectedBarberId + " " + model.SelectedServiceId);

            return RedirectToAction("Index", "Home");
        }
    }
}