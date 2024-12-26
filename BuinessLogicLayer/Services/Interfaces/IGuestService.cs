using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IGuestService
    {
        Task<List<GuestDto>> GetGuests();
        Task<GuestDto?> GetGuestById(int guestId);
        Task InsertGuest(GuestDto guestDto);
        Task DeleteGuest(int guestId);
        Task UpdateGuest(GuestDto guestDto);
    }
}
