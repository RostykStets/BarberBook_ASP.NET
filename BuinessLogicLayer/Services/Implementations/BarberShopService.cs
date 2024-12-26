using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class BarberShopService : IBarberShopService
    {
        private readonly IBarberShopRepository _barbershopRepository;

        public BarberShopService(IBarberShopRepository barbershopRepository)
        {
            _barbershopRepository = barbershopRepository;
        }

        public async Task DeleteBarberShop(int barbershopId)
        {
            await _barbershopRepository.DeleteBarberShop(barbershopId);
        }

        public async Task<BarberShopDto?> GetBarberShopById(int barbershopId)
        {
            var barbershop = await _barbershopRepository.GetBarberShopByID(barbershopId);

            BarberShopDto? barbershopDto = null;
            if (null != barbershop)
            {
                barbershopDto = new BarberShopDto(barbershop);
            }
            return barbershopDto;
        }

        public async Task<BarberShopDto?> GetBarberShopFirst()
        {
            BarberShopDto? barbershopDto = null;
            var barbershop = await _barbershopRepository.GetBarberShopFirst();
            if (barbershop == null) // No info about BarberShop in DB
            {
               // Logger log
            }
            else
            {
                barbershopDto = new BarberShopDto(barbershop);
            }

            return barbershopDto;
        }

        public async Task<List<BarberShopDto>> GetBarberShops()
        {
            var barbershops = await _barbershopRepository.GetBarberShops();
            var barbershopsDtos = from barbershop in barbershops
                                  select new BarberShopDto(barbershop);
            return barbershopsDtos.ToList();
        }

        public async Task InsertBarberShop(BarberShopDto barbershopDto)
        {
            BarberShop barbershop = barbershopDto.ToEntity();
            await _barbershopRepository.InsertBarberShop(barbershop);
        }

        public async Task UpdateBarberShop(BarberShopDto barbershopDto)
        {
            BarberShop barbershop = barbershopDto.ToEntity();
            await _barbershopRepository.UpdateBarberShop(barbershop);
        }
    }
}
