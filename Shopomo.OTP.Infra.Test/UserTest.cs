using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopomo.OTP.Domain.Interfaces.Repositories;
using Shopomo.OTP.Infra.Data.Repositories;
using Shopomo.OTP.Infra.Data.Context;
using Shopomo.OTP.Domain.Entities;

namespace Shopomo.OTP.Infra.Test
{
    [TestClass]
    public class UserTest
    {
        private readonly IUserRepository _userRepository;

        public UserTest()
        {
            _userRepository = new UserRepository(new ShopomoContext());
        }

        [TestMethod]
        public void Test_GetAll_Users()
        {
            var users = _userRepository.GetAll();

            Assert.IsTrue(users.Count > 0);
        }

        [TestMethod]
        public async void Test_Get_User_By_Email()
        {
            var user = await _userRepository.GetByEmailAsync("leonardo@gmail.com");

            Assert.AreEqual(user.Name, "Leonardo");
        }
    }
}
