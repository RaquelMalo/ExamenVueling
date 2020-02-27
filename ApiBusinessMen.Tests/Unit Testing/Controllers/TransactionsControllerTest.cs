using System;
using System.Web.Mvc;
using ApiBusinessMen.Controllers;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Services.Calculator;
using ApiBusinessMen.Services.Factory;
using ApiBusinessMen.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Controllers
{
    [TestClass]
    public class TransactionsControllerTest
    {
        private IRepository _repository;
        private ITransactionsBySkuFactory _factory;
        private IAlgorithm _algorithm;
        private ICalculator _calculator;

        [TestInitialize]
        public void SetupVariables()
        {
            _repository = new FakeRepository();
            _factory = new TransactionsBySkuFactory();
            _algorithm = new Algorithm(_repository);
            _calculator = new Calculator(_algorithm);
        }

        [TestMethod]
        public void IndexMethod()
        {
            //Arrange
            var controller = new TransactionsController(_repository, _factory, _calculator);
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
                new TransactionsController(null, _factory, _calculator);
            //Act and Assert
            Assert.ThrowsException<TransactionsControllerException>(() => controller.Index());
        }

        [TestMethod]
        public void GetBySkuMethod()
        {
            //Arrange
            var controller =
                new TransactionsController(_repository, _factory, _calculator);
            //Act
            var result = controller.GetBySku("Y0530");
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result is ActionResult);
        }

        [TestMethod]
        public void ErrorGetBySkuMethod()
        {
            //Arrange
            var controller =
                new TransactionsController(null, _factory, _calculator);
            //Act and Assert
            Assert.ThrowsException<TransactionsControllerException>(() => controller.GetBySku("Y0530"));
        }
    }
}
