using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopomo.Application.Interfaces;
using Shopomo.Application.App;
using Shopomo.OTP.Domain.Services;
using Shopomo.OTP.Domain.Interfaces.Services;
using Rhino.Mocks;
using Shopomo.OTP.Domain.Entities;
using System.Collections.Generic;
using Shopomo.OTP.Infra.Data.Repositories;
using Shopomo.Presentation.Client.Models;

namespace Shopomo.Application.Tests
{
    [TestClass]
    public class LoginTest
    {
        private ILoginAppService _loginAppService;

        public LoginTest()
        {
            _loginAppService = new LoginAppService(new LoginService(new LoginRepository()));
        }

        [TestMethod]
        public void Test_Length_Password()
        {
            var password = _loginAppService.GenerateOTP("999", DateTime.Now);
            Assert.IsTrue(password.Length == 6);
        }

        [TestMethod]
        public void Test_Two_Users_Password()
        {
            var password = _loginAppService.GenerateOTP("999", DateTime.Now);
            var password2 = _loginAppService.GenerateOTP("998", DateTime.Now);

            Assert.AreNotEqual(password, password2);
        }

        [TestMethod]
        public void Test_Password_Adding_Less_Than_30_Seconds()
        {
            var date1 = Convert.ToDateTime("03/11/2016 05:56:00");
            var date2 = Convert.ToDateTime("03/11/2016 05:56:29");

            var password = _loginAppService.GenerateOTP("999", date1);
            var password2 = _loginAppService.GenerateOTP("999", date2);

            Assert.AreEqual(password, password2);
        }

        [TestMethod]
        public void Test_Password_Adding_More_Than_30_Seconds()
        {
            var date1 = Convert.ToDateTime("03/11/2016 05:56:00");
            var date2 = Convert.ToDateTime("03/11/2016 05:56:32");

            var password = _loginAppService.GenerateOTP("999", date1);
            var password2 = _loginAppService.GenerateOTP("999", date2);

            Assert.AreNotEqual(password, password2);
        }

        [TestMethod]
        public void Test_Authenticate_Password()
        {
            var date1 = Convert.ToDateTime("03/11/2016 05:56:00");
            var date2 = Convert.ToDateTime("03/11/2016 05:56:28");

            var password = _loginAppService.GenerateOTP("999", date1);

            var result = _loginAppService.AuthenticateOTP("999", date2, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Fail_Authenticate_Password_By_UserId()
        {
            var date1 = Convert.ToDateTime("03/11/2016 05:56:00");
            var date2 = Convert.ToDateTime("03/11/2016 05:56:28");

            var password = _loginAppService.GenerateOTP("999", date1);

            var result = _loginAppService.AuthenticateOTP("998", date2, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Fail_Authenticate_Password_By_Date()
        {
            var date1 = Convert.ToDateTime("03/11/2016 05:56:01");
            var date2 = Convert.ToDateTime("03/11/2016 05:56:59");

            var password = _loginAppService.GenerateOTP("999", date1);

            var result = _loginAppService.AuthenticateOTP("999", date2, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Fail_Authenticate_Password_By_Wrong_Password()
        {
            var date2 = Convert.ToDateTime("03/11/2016 05:56:32");

            var password = "test";

            var result = _loginAppService.AuthenticateOTP("999", date2, password);

            Assert.IsFalse(result);
        }


    }
}
