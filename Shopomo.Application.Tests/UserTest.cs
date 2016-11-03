using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopomo.Application.Interfaces;
using Shopomo.Application.App;
using Shopomo.OTP.Domain.Services;
using Shopomo.OTP.Domain.Interfaces.Services;
using Rhino.Mocks;
using Shopomo.OTP.Domain.Entities;
using System.Collections.Generic;

namespace Shopomo.Application.Tests
{
    [TestClass]
    public class UserTest
    {
        private IUserAppService _userAppService;

        public UserTest()
        {
            var user1 = new User { UserId = 998, Email = "cadastro@gmail.com", Name = "Cadastro" };
            var user2 = new User { UserId = 999, Email = "leonardo@gmail.com", Name = "Leonardo" };

            var users = new List<User>() {user1, user2};

            var userService = MockRepository.GenerateStub<IUserService>();

            userService.Stub(h => h.GetAll())
                .IgnoreArguments()
                .Return(users);

            userService.Stub(h => h.GetById(999))
                .IgnoreArguments()
                .Return(user2);

            _userAppService = new UserAppService(userService);
        }

        [TestMethod]
        public void Test_GetAll_Users()
        {
            var users = _userAppService.GetAll();
            Assert.IsTrue(users.Count == 2);
        }

        [TestMethod]
        public void Test_Get_User_By_Id()
        {
            var user = _userAppService.GetById(999);
            Assert.AreEqual(user.Name, "Leonardo");
        }

    }
}
