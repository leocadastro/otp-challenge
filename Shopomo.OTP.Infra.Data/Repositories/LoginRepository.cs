using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text;
using Shopomo.OTP.Infra.Data.Helpers;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private OTPGenerator _otpGenerator;

        public LoginRepository()
        {
            _otpGenerator = new OTPGenerator();
        }

        public bool AuthenticateOTP(string userId, DateTime time, string password)
        {
            var iteration = _otpGenerator.GetIteration(time);
            var otpPassword = Generate(userId, iteration);

            return otpPassword == password;
        }

        public string GenerateOTP(string userId, DateTime time)
        {
            var iteration = _otpGenerator.GetIteration(time);
            return Generate(userId, iteration);
        }

        private string Generate(string userId, int iteration)
        {            
            var userIdIteration = string.Concat(userId, iteration.ToString());
            var bytes = Encoding.ASCII.GetBytes(userIdIteration);
            var otpPassword = _otpGenerator.GenerateOTP(bytes);

            return otpPassword;
        }

    }
}
