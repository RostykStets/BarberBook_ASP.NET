//using BusinessLogicLayer.DTOs;
//using BusinessLogicLayer.Services.Interfaces;
//using Serilog;
//using System.Net;


//namespace BusinessLogicLayer.Services.Implementations
//{
//    public class RegisterService : IRegisterService
//    {
//        private readonly IAdminService _adminService;
//        private readonly IBarberService _barberService;
//        private readonly IClientService _clientService;
//        private readonly IRegistrationKeyService _registrationKeyService;

//        public RegisterService(IAdminService adminService, IBarberService barberService, IClientService clientService, IRegistrationKeyService registrationKeyService)
//        {
//            _adminService = adminService;
//            _barberService = barberService;
//            _clientService = clientService;
//            _registrationKeyService = registrationKeyService;
//        }

//        public async Task<UserExtDto> Register(RegistrationDto registrationDto)
//        {
//            Log.Information("Register attempt with email: {Email}", registrationDto.Email);
//            UserExtDto userExtDto = new UserExtDto();
//            string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(registrationDto.Password);

//            if (registrationDto.UserType == _UserType.Client)
//            {
//                var existingClient = await _clientService.GetClientByEmail(registrationDto.Email);
//                if (existingClient != null)
//                {
//                    userExtDto.ErrorMsg = "Client already exists!";
//                }
//                else
//                {
//                    ClientDto newClient = new ClientDto(registrationDto, hashedPassword);
//                    await _clientService.InsertClient(newClient);
//                    userExtDto = new UserExtDto(newClient);
//                    Log.Information("Successfully registered as client with" +
//                        "Email: {Email}", newClient.Email);
//                }

//                goto finish;
//            }

//            var regKeyDto = await _registrationKeyService.GetRegistrationKeyFirst();
//            if (regKeyDto == null)
//            {
//                userExtDto.ErrorMsg = "No awailable registration keys!";
//                Log.Warning("No registration keys in the DataBase!");
//                goto finish;
//            }

//            if (registrationDto.UserType == _UserType.Barber)
//            {
//                if (!regKeyDto.Key.Equals(
//                    registrationDto.RegistrationKey.ToString()))
//                {
//                    userExtDto.ErrorMsg = "Invalid registration key!";
//                    goto finish;
//                }

//                var existingBarber = await _barberService.GetBarberByEmail(registrationDto.Email);
//                if (existingBarber != null)
//                {
//                    userExtDto.ErrorMsg = "Barber already exists!";
//                }
//                else
//                {
//                    BarberDto newBarber = new BarberDto(registrationDto, hashedPassword);
//                    await _barberService.InsertBarber(newBarber);
//                    userExtDto = new UserExtDto(newBarber);
//                    Log.Information("Successfully registered as barber with" +
//                        "Email: {Email}", newBarber.Email);
//                }

//                goto finish;
//            }

//            if (registrationDto.UserType == _UserType.Admin)
//            {
//                if (!regKeyDto.Key.Equals(
//                    registrationDto.RegistrationKey.ToString()))
//                {
//                    userExtDto.ErrorMsg = "Invalid registration key!";
//                    goto finish;
//                }

//                var existingAdmin = await _adminService.GetAdminByEmail(registrationDto.Email);
//                if (existingAdmin != null)
//                {
//                    userExtDto.ErrorMsg = "Admin already exists!";
//                }
//                else
//                {
//                    AdminDto newAdmin = new AdminDto(registrationDto, hashedPassword);
//                    await _adminService.InsertAdmin(newAdmin);
//                    userExtDto = new UserExtDto(newAdmin);
//                    Log.Information("Successfully registered as admin with" +
//                        "Email: {Email}", newAdmin.Email);
//                }

//                goto finish;
//            }


//            finish:
//            return userExtDto;
//        }
//    }
//}
