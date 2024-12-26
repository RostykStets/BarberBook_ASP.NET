using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IBarberShopRepository
    {
        Task<IEnumerable<BarberShop>> GetBarberShops();
        Task<BarberShop?> GetBarberShopByID(int barbershopId);
        Task<BarberShop?> GetBarberShopFirst();
        Task InsertBarberShop(BarberShop barbershop);
        Task DeleteBarberShop(int barbershopId);
        Task UpdateBarberShop(BarberShop barbershop);
        Task Save();
    }
}
