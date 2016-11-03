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

        public LoginController(IUserAppService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            var result = true;
            return Json(result);
        }
    }
}