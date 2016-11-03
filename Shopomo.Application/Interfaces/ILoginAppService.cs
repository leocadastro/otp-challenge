using Shopomo.OTP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.Application.Interfaces
{
    public interface ILoginAppService
    {
        string GenerateOTP(string userId, DateTime time);
        bool AuthenticateOTP(string userId, DateTime time, string password);
    }
}
