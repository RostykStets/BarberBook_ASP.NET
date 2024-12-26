using BarberLayered.Models;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BarberLayered.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginService _loginService;
        // private readonly IRegisterService _registerService;
        private readonly IEmailSenderService _emailSender;
        //private readonly IChangePasswordService _changePasswordService;
        private readonly IHttpContextAccessor _httpContextAccessor;       

        public AccountController(ILoginService loginService, //IRegisterService registerService,
            //IHttpContextAccessor httpContextAccessor, IChangePasswordService changePasswordService, IEmailSenderService emailSender)
            IHttpContextAccessor httpContextAccessor, IEmailSenderService emailSender)
        {
            _loginService = loginService;
            //_registerService = registerService;
            _httpContextAccessor = httpContextAccessor;
            //_changePasswordService = changePasswordService;
            _emailSender = emailSender;
        }

        // GET: /Account/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var result = await _loginService.Login(loginModel.Email, loginModel.Password);
            if (result.ErrorMsg != "")
            {
                TempData["ErrorMessage"] = result.ErrorMsg;
                return View(loginModel);
            }
            var session = _httpContextAccessor.HttpContext.Session;

            session.SetInt32("UserType", (int)result.UserType);
            session.SetString("Id", result.Id);

            switch (result.UserType)
            {
                case _UserType.Admin:
                    return RedirectToAction("Index", "AdminHome",
                        new Admin(result));
                case _UserType.Barber:
                    return RedirectToAction("Index", "BarberHome",
                        new Barber(result));
                case _UserType.Client:
                    return RedirectToAction("Index", "ClientHome", 
                        new Client(result));
                default:
                    return View(loginModel);
            }
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModelWithKey registerViewModel)
        //{
        //    if (!registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
        //    {
        //        TempData["ErrorMessage"] = "The password and confirmation password do not match.";
        //        return View(registerViewModel);
        //    }

        //    UserExtDto result;
        //    RegistrationDto registrationDto = new RegistrationDto()
        //    {
        //        RegistrationKey = registerViewModel.RegistrationKey,
        //        Name = registerViewModel.FirstName,
        //        Surname = registerViewModel.LastName,
        //        Email = registerViewModel.Email,
        //        Password = registerViewModel.Password,
        //        Phone = registerViewModel.Phone,
        //        UserType = (_UserType)registerViewModel.UserType
        //    };

        //    result = await _registerService.Register(registrationDto);
        //    if (result.ErrorMsg != "")
        //    {
        //        TempData["ErrorMessage"] = result.ErrorMsg;
        //        return View(registerViewModel);
        //    }

        //    var session = _httpContextAccessor.HttpContext.Session;

        //    session.SetInt32("UserType", (int)result.UserType);
        //    session.SetInt32("Id", result.Id);

        //    switch (result.UserType)
        //    {
        //        case _UserType.Admin:
        //            return RedirectToAction("Index", "AdminHome",
        //                new Admin(result));
        //        case _UserType.Barber:
        //            return RedirectToAction("Index", "BarberHome",
        //                new Barber(result));
        //        case _UserType.Client:
        //            return RedirectToAction("Index", "ClientHome",
        //                new Client(result));
        //        default:
        //            return RedirectToAction("Index", "BarberShop");
        //    }
        //}

        // GET: /Account/ChangePassword
        public IActionResult ChangePassword()
        {
            return View();
        }


        //// POST: /Account/ChangePassword
        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!model.NewPassword.Equals(model.ConfirmNewPassword))
        //    {
        //        TempData["ErrorMessage"] = "The password and confirmation password do not match.";
        //        return View(model);
        //    }

        //    UserExtDto result;
        //    var session = _httpContextAccessor.HttpContext.Session;

        //    ChangePasswordDto changePasswordDto = new ChangePasswordDto()
        //    {
        //        Id = session.GetInt32("Id") ?? default,
        //        UserType = (_UserType)(session.GetInt32("UserType") ?? default),
        //        ConfirmNewPassword = model.ConfirmNewPassword,
        //        CurrentPassword = model.CurrentPassword,
        //        NewPassword = model.NewPassword,
        //        ErrorMsg = ""
        //    };

        //    result = await _changePasswordService.ChangePassword(changePasswordDto);
        //    if (result.ErrorMsg != "")
        //    {
        //        TempData["ErrorMessage"] = result.ErrorMsg;
        //        return View(model);
        //    }
        //    else
        //    {
        //        switch (result.UserType)
        //        {
        //            case _UserType.Admin:
        //                return RedirectToAction("Index", "AdminHome",
        //                    new Admin(result));
        //            case _UserType.Barber:
        //                return RedirectToAction("Index", "BarberHome",
        //                    new Barber(result));
        //            case _UserType.Client:
        //                return RedirectToAction("Index", "ClientHome",
        //                    new Client(result));
        //            default:
        //                return RedirectToAction("Index", "BarberShop");
        //        }
        //    }
        //}


        // POST: /Account/Logout
        [HttpPost]
        [Authorize]
        public IActionResult Logout()
        {
            // User session close logic
            return RedirectToAction("Index", "BarberShop");
        }
    }
}
