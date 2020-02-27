using System.Collections.Generic;
using ApiBusinessMen.Services.Calculator;
using ApiBusinessMen.Services.Repository;
using ApiBusinessMen.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Services
{
    [TestClass]
    public class CalculatorTest
    {
        private IRepository _repository;
        private IAlgorithm _algorithm;
        private ICalculator _calculator;

        [TestInitialize]
        public void SetupVariables()
        {
            _repository = new FakeRepository();
            _algorithm = new Algorithm(_repository);
            _calculator = new Calculator(_algorithm);
        }

        [TestMethod]
        public void CalculateRateEur()
        {
            //Arrange
            var transBySku = new List<TransactionsBySku>()
            {
                new TransactionsBySku()
                {
                    Num = "1",
                    Sku = "Y0530",
                    Amount = 23.5m,
                    Currency = "EUR"
                },
                new TransactionsBySku()
                {
                    Num = "2",
                    Sku = "Y0530",
                    Amount = 41m,
                    Currency = "USD"
                }
            };
            //Act
            var result = _calculator.TotalInEuros(transBySku);
            //Assert
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(result[2].Num, "TOTAL");
            Assert.AreEqual(result[2].Amount, 51.39m);
        }
    }
}