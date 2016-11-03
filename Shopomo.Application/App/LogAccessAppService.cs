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
    public class LogAccessAppService : AppServiceBase<LogAccess>, ILogAccessAppService
    {
        private readonly ILogAccessService _logAccessService;

        public LogAccessAppService(ILogAccessService logAccessService)
            : base(logAccessService)
        {
            _logAccessService = logAccessService;
        }
    }
}
