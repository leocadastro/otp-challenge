using Shopomo.Application.Interfaces;
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

        public LoginController(IUserAppService userService, ILoginAppService loginService)
        {
            _userService = userService;
            _loginService = loginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            var result = false;
            var user = await _userService.GetByEmailAsync(loginViewModel.Email);
            var time = DateTime.Now;

            if (user != null && !string.IsNullOrEmpty(loginViewModel.Password))
            {
                result = _loginService.AuthenticateOTP(user.UserId.ToString(), time, loginViewModel.Password);
                return Json(result);
            }

            
            return Json(result);
        }
    }
}