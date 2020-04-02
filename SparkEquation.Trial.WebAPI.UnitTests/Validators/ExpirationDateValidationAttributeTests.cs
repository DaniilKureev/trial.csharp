using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI.Data.Validation;
using System;

namespace SparkEquation.Trial.WebAPI.UnitTests.Validators
{
    [TestClass]
    public class ExpirationDateValidationAttributeTests
    {
        [TestMethod]
        public void IsValid_WhenValueIsCorrect_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new ExpirationDateValidationAttribute(30);
            var testDate = DateTime.Now.AddDays(30);

            //Act
            var result = validator.IsValid(testDate);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_WhenValueIsNotCorrect_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new ExpirationDateValidationAttribute(30);
            var testDate = DateTime.Now.AddDays(29);

            //Act
            var result = validator.IsValid(testDate);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_WhenValueIsNull_ValueSuccessfullValidated()
        {
            //Arrange
            var validator = new ExpirationDateValidationAttribute(30);
            DateTime? testDate = null;

            //Act
            var result = validator.IsValid(testDate);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
