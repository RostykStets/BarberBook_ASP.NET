using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBarberService
    {
        Task<List<BarberDto>> GetBarbers();
        Task<BarberDto?> GetBarberById(string barberId);
        Task<BarberDto?> GetBarberByEmail(string email);
    }
}
