using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserExtDto> Login(string email, string password);
    }
}
