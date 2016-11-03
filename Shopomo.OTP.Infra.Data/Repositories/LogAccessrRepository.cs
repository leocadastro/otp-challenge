using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class LogAccessrRepository : RepositoryBase<LogAccess>, ILogAccessRepository
    {
        public LogAccessrRepository(ShopomoContext dbContext)
            : base(dbContext)
        {

        }

    }
}
