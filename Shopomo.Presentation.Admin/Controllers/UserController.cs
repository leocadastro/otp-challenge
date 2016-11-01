using AutoMapper;
using Shopomo.Application.Interfaces;
using Shopomo.OTP.Domain.Entities;
using Shopomo.Presentation.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shopomo.Presentation.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

            return View(usersViewModel);
        }
    }
}