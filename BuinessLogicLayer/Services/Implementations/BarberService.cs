using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class BarberService : IBarberService
    {
        private readonly IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<List<BarberDto>> GetBarbers()
        {
            var barbers = await _barberRepository.GetBarbers();
            var barbersDtos = from barber in barbers
                              select new BarberDto(barber);
            return barbersDtos.ToList();
        }

        public async Task<BarberDto?> GetBarberById(string barberId)
        {
            var barber = await _barberRepository.GetBarberByID(barberId);

            BarberDto? barberDto = null;
            if (null != barber)
            {
                barberDto = new BarberDto(barber);
            }
            return barberDto;
        }

        public async Task<BarberDto?> GetBarberByEmail(string email)
        {
            Barber? barber = await _barberRepository.GetBarberByEmail(email);
            BarberDto? barberDto = null;
            if (barber != null)
            {
                barberDto = new BarberDto(barber);
            }
            return barberDto;
        }
    }
}
