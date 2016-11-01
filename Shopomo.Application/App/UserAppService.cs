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
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
            : base(userService)
        {
            _userService = userService;
        }
    }
}
