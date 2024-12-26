using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{
    public class BarberAppointmentsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IServiceService _serviceService;
        private readonly IBarberService _barberService;
        private readonly IVisitService _visitService;

        public BarberAppointmentsController(
            IClientService clientService,
            IServiceService serviceService,
            IBarberService barberService,
            IVisitService visitService)
        {
            _clientService = clientService;
            _serviceService = serviceService;
            _barberService = barberService;
            _visitService = visitService;
        }

        public async Task<IActionResult> BarberAppointments(string barberId)
        {
            var barber = await _barberService.GetBarberById(barberId);
            if (barber == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetServices();
            var clients = await _clientService.GetClients();
            var visits = await _visitService.GetVisits();

            var barberAppointments = (from visit in visits
                                      where visit.fk_BarberId == barberId &&
                                          (visit.Date > DateOnly.FromDateTime(DateTime.Now) ||
                                              (visit.Date == DateOnly.FromDateTime(DateTime.Now) && visit.Time > TimeOnly.FromDateTime(DateTime.Now)))
                                      select visit).ToList();

            var groupedAppointments = (from visit in barberAppointments
                                       orderby visit.Date, visit.Time
                                       group visit by visit.Date).ToList();

            ViewBag.Barber = barber;
            ViewBag.Services = services;
            ViewBag.Clients = clients;

            return View(groupedAppointments);
        }

        public async Task<IActionResult> BarberAppointmentsHistory(string barberId)
        {
            var barber = await _barberService.GetBarberById(barberId);
            if (barber == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetServices();
            var clients = await _clientService.GetClients();
            var visits = await _visitService.GetVisits();

            var barberAppointments = (from visit in visits
                                      where visit.fk_BarberId == barberId &&
                                          (visit.Date < DateOnly.FromDateTime(DateTime.Now) ||
                                              (visit.Date == DateOnly.FromDateTime(DateTime.Now) && visit.Time < TimeOnly.FromDateTime(DateTime.Now)))
                                      select visit).ToList();

            var groupedAppointments = (from visit in barberAppointments
                                       orderby visit.Date, visit.Time
                                       group visit by visit.Date).ToList();

            ViewBag.Barber = barber;
            ViewBag.Services = services;
            ViewBag.Clients = clients;

            return View(groupedAppointments);
        }

        public async Task<IActionResult> DeleteAppointment(int id, string barberId)
        {
            //var result = await _visitService.DeleteVisit(id);
            //if (result)
            //{
            //    Log.Information("Appointment with id={Id} was successfully deleted", id);
            //}
            //else
            //{
            //    Log.Error("Failed to delete appointment with id={Id}", id);
            //}

            return RedirectToAction("BarberAppointments", new { barberId = barberId });
        }

    }
}
