using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBarberShopService
    {
        Task<List<BarberShopDto>> GetBarberShops();
        Task<BarberShopDto?> GetBarberShopById(int barbershopId);
        Task<BarberShopDto?> GetBarberShopFirst();
        Task InsertBarberShop(BarberShopDto barbershopDto);
        Task DeleteBarberShop(int barbershopId);
        Task UpdateBarberShop(BarberShopDto barbershopDto);
    }
}
