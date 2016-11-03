using Shopomo.OTP.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Shopomo.OTP.Domain.Interfaces.Repositories
{
    public interface ILoginRepository 
    {
        string GenerateOTP(string userId, DateTime time);
        bool AuthenticateOTP(string userId, DateTime time, string password);
    }
}
