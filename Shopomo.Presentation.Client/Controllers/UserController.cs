using AutoMapper;
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
    public class UserController : Controller
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

            return Json(usersViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}