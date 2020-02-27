using ApiBusinessMen.Models;
using ApiBusinessMen.Services.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiBusinessMen.Tests.Unit_Testing.Services
{
    [TestClass]
    public class SpecificationTest
    {
        private readonly ISpecification<Transactions> _specification;

        public SpecificationTest()
        {
            _specification = new TransactionsBySkuSpecification("Y0503");
        }

        [TestMethod]
        public void TrueSpecification()
        {
            //Arrange
            var trans = new Transactions()
            {
                Sku = "Y0503",
                Amount = 26.8m,
                Currency = "EUR"
            }; 
            //Act and Assert
            Assert.IsTrue(_specification.IsSatisfiedBy(trans));
        }
        
       [TestMethod]
        public void FalseSpecification()
        {
            //Arrange
            var trans = new Transactions()
            {
                Sku = "Q8348",
                Amount = 26.8m,
                Currency = "EUR"
            };
            Assert.IsFalse(_specification.IsSatisfiedBy(trans));
        }
    }
}
