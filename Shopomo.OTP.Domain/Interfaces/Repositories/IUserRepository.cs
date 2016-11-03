using Shopomo.OTP.Domain.Entities;
using System.Threading.Tasks;

namespace Shopomo.OTP.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
