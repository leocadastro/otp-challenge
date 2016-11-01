using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ShopomoContext dbContext)
            : base(dbContext)
        {

        }
    }
}
