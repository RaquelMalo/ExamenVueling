using System;
using System.Collections.Generic;
using System.Linq;
using ApiBusinessMen.CrossCutting.Exceptions;
using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Repository;
using ApiBusinessMen.Services.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Services
{
    [TestClass]
    public class FilterTest
    {
        private IRepository _repository;
        private IEnumerable<Transactions> _trans;
        private ISpecification<Transactions> _specification;

        [TestInitialize]
        public void SetupVariables()
        {
            _repository = new FakeRepository();
            _trans = _repository.GetTransactions().Result;
            _specification = new TransactionsBySkuSpecification("Y0530");
        }

        [TestMethod]
        public void FilteredElements()
        {
            //Arrange
            var filter = new MyFilter();
            //Act
            var filteredList = filter.GetElements(_trans, _specification);
            //Assert
            Assert.AreEqual(2, filteredList.Count());
        }
    }
}
