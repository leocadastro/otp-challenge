using Shopomo.Application.Interfaces;
using Shopomo.OTP.Domain.Entities;
using Shopomo.Presentation.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shopomo.Presentation.Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserAppService _userService;
        private readonly ILoginAppService _loginService;
        private readonly ILogAccessAppService _logAccessService;

        public LoginController(IUserAppService userService, ILoginAppService loginService, ILogAccessAppService logAccessService)
        {
            _userService = userService;
            _loginService = loginService;
            _logAccessService = logAccessService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GeneratePassword(int userId)
        {
            var time = DateTime.Now;
            string password = _loginService.GenerateOTP(userId.ToString(), time);

            return Json(password);
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            var result = false;
            var user = await _userService.GetByEmailAsync(loginViewModel.Email);
            var time = DateTime.Now;

            if (user != null && !string.IsNullOrEmpty(loginViewModel.Password))
            {
                result = _loginService.AuthenticateOTP(user.UserId.ToString(), time, loginViewModel.Password.Trim());

                try
                {
                    await _logAccessService.AddAsync(MapLogAccess(user, result, time));
                }
                catch (Exception)
                {
                    //Implement log
                }

                return Json(result);
            }

            
            return Json(result);
        }

        private LogAccess MapLogAccess(User user, bool fail, DateTime time)
        {
            return new LogAccess()
            {
                Email = user.Email,
                Time = time,
                Fail = fail
            };
        }
    }
}