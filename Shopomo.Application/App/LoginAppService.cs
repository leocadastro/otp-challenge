using Shopomo.Application.Interfaces;
using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.Application.App
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginService _loginService;

        public LoginAppService(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public bool AuthenticateOTP(string userId, DateTime time, string password)
        {
            return _loginService.AuthenticateOTP(userId, time, password);
        }

        public string GenerateOTP(string userId, DateTime time)
        {
            return _loginService.GenerateOTP(userId, time);
        }
    }
}
