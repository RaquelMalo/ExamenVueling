using System;
using System.Collections.Generic;
using ApiBusinessMen.Services.Factory;
using ApiBusinessMen.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Services
{
    [TestClass]
    public class TransactionsBySkuFactoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var factory = new TransactionsBySkuFactory();
            //Act
            var result = factory.Create("Y0530");
            //Assert
            Assert.AreEqual(typeof(List<TransactionsBySku>), result.GetType());
        }
    }
}
