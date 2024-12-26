using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BarberLayered.Controllers
{ 
    public class ClientAppointmentsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IServiceService _serviceService;
        private readonly IBarberService _barberService;
        private readonly IVisitService _visitService;

        public ClientAppointmentsController(
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

        public async Task<IActionResult> ClientAppointments(string clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetServices();
            var barbers = await _barberService.GetBarbers();
            var visits = await _visitService.GetVisits();

            var clientAppointments = (from visit in visits
                                      where visit.fk_ClientId == clientId &&
                                          (visit.Date > DateOnly.FromDateTime(DateTime.Now) ||
                                              (visit.Date == DateOnly.FromDateTime(DateTime.Now) && visit.Time > TimeOnly.FromDateTime(DateTime.Now)))
                                      select visit).ToList();

            var groupedAppointments = (from visit in clientAppointments
                                       orderby visit.Date, visit.Time
                                       group visit by visit.Date).ToList();

            ViewBag.Client = client;
            ViewBag.Services = services;
            ViewBag.Barbers = barbers;

            return View(groupedAppointments);

        }

        public async Task<IActionResult> ClientAppointmentsHistory(string clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound();
            }

            var services = await _serviceService.GetServices();
            var barbers = await _barberService.GetBarbers();
            var visits = await _visitService.GetVisits();

            var clientAppointments = (from visit in visits
                                      where visit.fk_ClientId == clientId &&
                                          (visit.Date < DateOnly.FromDateTime(DateTime.Now) ||
                                              (visit.Date == DateOnly.FromDateTime(DateTime.Now) && visit.Time < TimeOnly.FromDateTime(DateTime.Now)))
                                      select visit).ToList();

            var groupedAppointments = (from visit in clientAppointments
                                       orderby visit.Date, visit.Time
                                       group visit by visit.Date).ToList();

            ViewBag.Client = client;
            ViewBag.Services = services;
            ViewBag.Barbers = barbers;

            return View(groupedAppointments);

        }

        public async Task<IActionResult> DeleteAppointment(int id, string clientId)
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

            return RedirectToAction("ClientAppointments", new { clientId = clientId });
        }

    }
}
