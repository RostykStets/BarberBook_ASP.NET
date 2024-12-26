using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public async Task<List<GuestDto>> GetGuests()
        {
            var guests = await _guestRepository.GetGuests();
            var guestsDtos = from guest in guests
                             select new GuestDto(guest);
            return guestsDtos.ToList();
        }
        public async Task<GuestDto?> GetGuestById(int guestId)
        {
            var guest = await _guestRepository.GetGuestByID(guestId);
            GuestDto? guestDto = null;
            if (guest != null)
            {
                guestDto = new GuestDto(guest);
            }
            return guestDto;
        }
        public async Task InsertGuest(GuestDto guestDto)
        {
            Guest guest = guestDto.ToEntity();
            await _guestRepository.InsertGuest(guest);
        }
        public async Task DeleteGuest(int guestId)
        {
            await _guestRepository.DeleteGuest(guestId);
        }
        public async Task UpdateGuest(GuestDto guestDto)
        {
            Guest guest = guestDto.ToEntity();
            await _guestRepository.UpdateGuest(guest);
        }
    }
}
