using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;

namespace SparkEquation.Trial.WebAPI.UnitTests.Services
{
    [TestClass]
    public class ProductProcessorTests
    {
        [TestMethod]
        public void AdjustProductToFeatured_WhenRaitingIsEqualToBound_ProducIsNotFeatured()
        {
            //Arrange
            var processor = new ProductProcessor();
            var product = new Product()
            {
                Rating = Consts.RaitingBoundValue
            };

            //Act
            processor.AdjustProductToFeatured(product);

            //Assert
            Assert.IsFalse(product.Featured);
        }

        [TestMethod]
        public void AdjustProductToFeatured_WhenRaitingIsLessThanBound_ProducIsNotFeatured()
        {
            //Arrange
            var processor = new ProductProcessor();
            var product = new Product()
            {
                Rating = Consts.RaitingBoundValue - 1d
            };

            //Act
            processor.AdjustProductToFeatured(product);

            //Assert
            Assert.IsFalse(product.Featured);
        }
        [TestMethod]
        public void AdjustProductToFeatured_WhenRaitingIsGreaterThanBound_ProducIsFeatured()
        {
            //Arrange
            var processor = new ProductProcessor();
            var product = new Product()
            {
                Rating = Consts.RaitingBoundValue + 1d
            };

            //Act
            processor.AdjustProductToFeatured(product);

            //Assert
            Assert.IsTrue(product.Featured);
        }
    }
}
