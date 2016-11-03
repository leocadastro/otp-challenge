using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;

namespace Shopomo.OTP.Domain.Services
{
    public class LogAccessService : ServiceBase<LogAccess>, ILogAccessService
    {
        private readonly ILogAccessRepository _logAccessRepository;

        public LogAccessService(ILogAccessRepository logAccessRepository)
            : base(logAccessRepository)
        {
            _logAccessRepository = logAccessRepository;
        }
    }
}
