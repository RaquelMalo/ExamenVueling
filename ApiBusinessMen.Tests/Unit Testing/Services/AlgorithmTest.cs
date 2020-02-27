using System;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Services.Calculator;
using ApiBusinessMen.Services.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Services
{
    [TestClass]
    public class AlgorithmTest
    {
        private IRepository _repository;
        private IAlgorithm _algorithm;

        [TestInitialize]
        public void SetupVariables()
        {
            _repository = new FakeRepository();
            _algorithm = new Algorithm(_repository);
        }

        [TestMethod]
        public void CalculateRateEur()
        {
            //Act
            var result = _algorithm.CalculateRate("EUR");
            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculateRateCad()
        {
            //Act
            var result = _algorithm.CalculateRate("CAD");
            //Assert
            Assert.AreEqual(0.95m, result);
        }

        [TestMethod]
        public void CalculateRateAud()
        {
            //Act
            var result = _algorithm.CalculateRate("AUD");
            //Assert
            Assert.AreEqual(0.7315m, result);
        }

        [TestMethod]
        public void CalculateRateUsd()
        {
            //Act
            var result = _algorithm.CalculateRate("USD");
            //Assert
            Assert.AreEqual(0.680295m, result);
        }

        [TestMethod]
        public void RateCalculatorException()
        {
            //Act and Assert
            Assert.ThrowsException<CalculatorException>(() => _algorithm.CalculateRate("YEN"));
        }
    }
}
