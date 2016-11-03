using Shopomo.OTP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.OTP.Domain.Interfaces.Services
{
    public interface ILoginService 
    {
        string GenerateOTP(string userId, DateTime time);
        bool AuthenticateOTP(string userId, DateTime time, string password);
    }
}
