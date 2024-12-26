using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IBarberRepository
    {
        Task<IEnumerable<Barber>> GetBarbers();
        Task<Barber?> GetBarberByID(string barberId);
        Task<Barber?> GetBarberByEmail(string email);
    }
}
