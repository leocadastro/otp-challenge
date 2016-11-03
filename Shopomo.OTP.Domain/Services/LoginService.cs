using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;

namespace Shopomo.OTP.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public bool AuthenticateOTP(string userId, DateTime time, string password)
        {
            return _loginRepository.AuthenticateOTP(userId, time, password);
        }

        public string GenerateOTP(string userId, DateTime time)
        {
            return _loginRepository.GenerateOTP(userId, time);
        }
    }
}
