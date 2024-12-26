using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetGuests();
        Task<Guest?> GetGuestByID(int guestId);
        Task InsertGuest(Guest guest);
        Task DeleteGuest(int guestId);
        Task UpdateGuest(Guest guest);
        Task Save();
    }
}
