using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberLayered.Controllers
{
    public class ServiceAppointmentController : Controller
    {
        public IActionResult ServiceAppointment()
        {
            return View();
        }
    }
}




//using Microsoft.AspNetCore.Mvc;
//using BarberLayered.Models;
//using BusinessLogicLayer.Services;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BarberLayered.Controllers
//{
//    public class ServiceAppointmentController : Controller
//    {
//        private readonly IBarberService _barberService;
//        private readonly IServiceService _serviceService;
//        private readonly IVisitService _visitService;

//        public ServiceAppointmentController(IBarberService barberService, IServiceService serviceService, IVisitService visitService)
//        {
//            _barberService = barberService;
//            _serviceService = serviceService;
//            _visitService = visitService;
//        }

//        public async Task<IActionResult> ServiceAppointment(int barberId, int serviceId)
//        {
//            var barber = await _barberService.GetBarberById(barberId);
//            var service = await _serviceService.GetServiceById(serviceId);
//            var visits = (await _visitService.GetVisitsByBarberId(barberId)).Select(v => new Visit(v));

//            var model = new ServiceAppointmentViewModel
//            {
//                Barber = barber,
//                Service = service,
//                Visits = visits
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> MakeAppointment(Visit visit)
//        {
//            var visitDto = new VisitDto
//            {
//                fk_ClientId = visit.fk_ClientId,
//                fk_BarberId = visit.fk_BarberId,
//                fk_ServiceId = visit.fk_ServiceId,
//                VisitorFullName = visit.VisitorFullName,
//                Date = visit.Date,
//                StartTime = visit.StartTime,
//                EndTime = visit.EndTime
//            };

//            await _visitService.CreateVisit(visitDto);

//            return RedirectToAction("ServiceAppointment", new { barberId = visit.fk_BarberId, serviceId = visit.fk_ServiceId });
//        }
//    }
//}

