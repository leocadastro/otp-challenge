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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = Mapper.Map<UserViewModel, User>(model);
                var userBd = await _userService.GetByEmailAsync(user.Email);
                if (userBd == null)
                {
                    var result = await _userService.AddAsync(user);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Email já existe";
                    return View(model);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            var usersViewModel = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

            return Json(usersViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int userId)
        {
            var user = await _userService.GetByIdAsync(userId);

            var result = await _userService.RemoveAsync(user);

            return result == 1 ? Json(true, JsonRequestBehavior.AllowGet) : Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}