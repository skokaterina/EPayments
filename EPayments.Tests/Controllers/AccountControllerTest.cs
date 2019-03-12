using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using EPayments.Controllers;
using EPayments.Models;
using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPayments.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private AccountController controller;
        private Mock<UserManager<ApplicationUser>> userManagerMock;
        private Mock<AuthRepository> userManagerMock1;

        
        [TestInitialize]
        public void SetupContext()
        {
            controller = new AccountController();
        }

        [TestMethod]
        public void Register_GetView()
        {
            var result = controller.Register();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }               
    }
}
