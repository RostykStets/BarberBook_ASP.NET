//using BusinessLogicLayer.DTOs;
//using BusinessLogicLayer.Services.Interfaces;
//using DataAccessLayer.Entities;
//using DataAccessLayer.Repositories.Interfaces;
//using Serilog;

//namespace BusinessLogicLayer.Services.Implementations
//{
//    public class ChangePasswordService : IChangePasswordService
//    {
//        private readonly IBarberService _barberService;
//        private readonly IClientService _clientService;
//        private readonly IAdminService _adminService;

//        public ChangePasswordService(IClientService clientService, IBarberService barberService, IAdminService adminService)
//        {
//            _clientService = clientService;
//            _barberService = barberService;
//            _adminService = adminService;
//        }

//        public async Task<UserExtDto> ChangePassword(ChangePasswordDto changePasswordDto)
//        {
//            Log.Information("ChangePassword attempt with Id: {Id}", changePasswordDto.Id);

//            UserExtDto userExtDto = new UserExtDto();
//            string storedPasswordHash;

//            switch(changePasswordDto.UserType)
//            {
//                case (_UserType.Client):
//                    var client = await _clientService.GetClientById(changePasswordDto.Id);
//                    if (client != null)
//                    {
//                        storedPasswordHash = client.PasswordHash;
//                        if (BCrypt.Net.BCrypt.EnhancedVerify(changePasswordDto.CurrentPassword, storedPasswordHash))
//                        {
//                            client.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(changePasswordDto.NewPassword);
//                            await _clientService.UpdateClient(client);

//                            Log.Information("Successfully changed password for client with Id: {Id}", client.Id);
//                            userExtDto = new UserExtDto(client);
//                        }
//                        else
//                        {
//                            userExtDto.ErrorMsg = "Wrong password";
//                        }
//                    }
//                    break;
//                case (_UserType.Barber):
//                    var barber = await _barberService.GetBarberById(changePasswordDto.Id);
//                    if (barber != null)
//                    {
//                        storedPasswordHash = barber.PasswordHash;
//                        if (BCrypt.Net.BCrypt.EnhancedVerify(changePasswordDto.CurrentPassword, storedPasswordHash))
//                        {
//                            barber.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(changePasswordDto.NewPassword);
//                            await _barberService.UpdateBarber(barber);

//                            Log.Information("Successfully changed password for barber with Id: {Id}", barber.Id);
//                            userExtDto = new UserExtDto(barber);
//                        }
//                        else
//                        {
//                            userExtDto.ErrorMsg = "Wrong password";
//                        }
//                    }
//                    break;
//                case (_UserType.Admin):
//                    var admin = await _adminService.GetAdminById(changePasswordDto.Id);
//                    if (admin != null)
//                    {
//                        storedPasswordHash = admin.PasswordHash;
//                        if (BCrypt.Net.BCrypt.EnhancedVerify(changePasswordDto.CurrentPassword, storedPasswordHash))
//                        {
//                            admin.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(changePasswordDto.NewPassword);
//                            await _adminService.UpdateAdmin(admin);

//                            Log.Information("Successfully changed password for admin with Id: {Id}", admin.Id);
//                            userExtDto = new UserExtDto(admin);
//                        }
//                        else
//                        {
//                            userExtDto.ErrorMsg = "Wrong password";
//                        }
//                    }
//                    break;
//                default:
//                    userExtDto.ErrorMsg = $"No user found by Id={changePasswordDto.Id}";
//                    break;
//            }

//            return userExtDto;
//        }
//    }
//}
