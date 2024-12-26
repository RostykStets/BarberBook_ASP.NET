using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using BusinessLogicLayer.Services.Interfaces;

namespace BarberLayered.Controllers
{
    public class BarberScheduleController : Controller
    {
        private readonly IBarberService _barberService;
        private readonly IScheduleService _scheduleService;

        public BarberScheduleController(IBarberService barberService, IScheduleService scheduleService)
        {
            _barberService = barberService;
            _scheduleService = scheduleService;
        }

        public async Task<IActionResult> BarberSchedule(string barberId)
        {
            var barber = await _barberService.GetBarberById(barberId);
            if (barber == null)
            {
                Log.Error("No info about Barber with id={Id} was found in the DataBase", barberId);
                return NotFound();
            }

            //var allSchedules = await _scheduleService.GetSchedules();
            var barberSchedules = await _scheduleService.GetScheduleByBarberID(barberId);
            //var barberSchedules = allSchedules.Where(s => s.fk_BarberId == barberId).ToList();

            ViewBag.Barber = barber;
            ViewBag.Schedules = barberSchedules;

            return View(barber);
        }
    }
}
