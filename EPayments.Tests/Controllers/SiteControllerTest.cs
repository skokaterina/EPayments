using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EPayments.Controllers;
using EPayments.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPayments.Tests.Controllers
{
    [TestClass]
    public class SiteControllerTest
    {
        private SiteController controller;
        private Mock<IRepository> mock;

        [TestInitialize]
        public void SetupContext()
        {
            mock = new Mock<IRepository>();
            controller = new SiteController(mock.Object);
        }          
       
        /// <summary>
        /// Создание: сайт заполнен корректно, идет переадресация на Index
        /// </summary>
        [TestMethod]
        public void Create_ModelCorrect()
        {
            // Arrange            
            var site = new Site() { Id = Guid.NewGuid(), URL = "https://metanit.com/" };
            
            // Act
            var result = controller.Create(site) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        /// <summary>
        /// Создание: сайт заполнен некорректно
        /// </summary>
        [TestMethod]
        public void Create_ModelError()
        {
            // Arrange
            var site = new Site();
            controller.ModelState.AddModelError("Name", "Название модели не установлено");
            
            // Act
            var result = controller.Create(site) as ViewResult;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void Create_SaveModel()
        {
            // Arrange
            var site = new Site();

            // Act
            var result = controller.Create(site) as RedirectToRouteResult;

            // Assert
            mock.Verify(a => a.Create(site));
            mock.Verify(a => a.Save());
        }

        [TestMethod]
        public void GetSites_ShouldReturnAllSites()
        {
            //var list = GetTestSites();
            //var controller = new SiteController(testProducts);

            //var result = controller.GetSites() as PartialViewResult;
            //Assert.AreEqual(list.Count, result.Model.Count);
        }

        private List<Site> GetTestSites()
        {
            var ret = new List<Site>();
            ret.Add(new Site { Id = Guid.NewGuid(), URL = "https://msdn.microsoft1.com", Name = "Name 1", Status = 0, IsBlocked = false });
            ret.Add(new Site { Id = Guid.NewGuid(), URL = "https://msdn.microsoft.com", Name = "Name 2", Status = 1, IsBlocked = false });
            ret.Add(new Site { Id = Guid.NewGuid(), URL = "http://msdn.microsoft3.com", Name = "Name 3",  IsBlocked = true });
            ret.Add(new Site { Id = Guid.NewGuid(), URL = "https://msdn.microsoft.com",  Status = 0, IsBlocked = false });

            return ret;
        }
    }
}
