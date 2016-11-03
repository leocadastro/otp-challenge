using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginRepository()
        {

        }

        public bool AuthenticateOTP(string userId, DateTime time, string password)
        {
            return true;
        }

        public string GenerateOTP(string userId, DateTime time)
        {
            return "testeOtp";
        }

    }
}
