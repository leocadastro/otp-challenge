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
    public class LogAccessController : Controller
    {
        private readonly ILogAccessAppService _logAccessService;

        public LogAccessController(ILogAccessAppService logAccessService)
        {
            _logAccessService = logAccessService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var logs = await _logAccessService.GetAllAsync();
            var logsViewModel = Mapper.Map<IEnumerable<LogAccess>, IEnumerable<LogAccessViewModel>>(logs);

            return Json(logsViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}