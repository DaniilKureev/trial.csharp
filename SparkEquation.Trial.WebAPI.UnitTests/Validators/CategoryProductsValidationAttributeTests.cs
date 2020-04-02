using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Data.Validation;
using System.Collections.Generic;

namespace SparkEquation.Trial.WebAPI.UnitTests.Validators
{
    [TestClass]
    public class CategoryProductsValidationAttributeTests
    {
        [TestMethod]
        public void IsValid_WhenValueIsCorrect_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new CategoryProductsValidationAttribute(1,5);
            var list = new List<CategoryProduct>()
            { 
                new CategoryProduct(),
                new CategoryProduct() 
            };

            //Act
            var result = validator.IsValid(list);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenValueIsNotCorrect_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new CategoryProductsValidationAttribute(1, 5);
            var list = new List<CategoryProduct>()
            { };

            //Act
            var result = validator.IsValid(list);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenValueIsNull_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new CategoryProductsValidationAttribute(1, 5);
            List<Product> list = null;

            //Act
            var result = validator.IsValid(list);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
