using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ShopomoContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x=>x.Email == email);
        }
    }
}
