using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;

namespace Shopomo.OTP.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
