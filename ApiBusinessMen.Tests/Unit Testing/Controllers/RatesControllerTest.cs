using System;
using System.Web.Mvc;
using ApiBusinessMen.Controllers;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Controllers
{
    [TestClass]
    public class RatesControllerTest
    {
        private IRepository _repository;

        [TestInitialize]
        public void SetupVariables()
        {
            _repository = new FakeRepository();
        }

        [TestMethod]
        public void IndexMethod()
        {
            //Arrange
            var controller = new RatesController(_repository);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is ActionResult);
        }

        [TestMethod]
        public void ErrorIndexMethod()
        {
            //Arrange
            var controller =
                new RatesController(null);
            //Act and Assert
            Assert.ThrowsException<RatesControllerException>(() => controller.Index());
        }
    }
}
