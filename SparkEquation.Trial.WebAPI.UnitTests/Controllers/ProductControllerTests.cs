using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.UnitTests.Mocks;
using System;
using System.Reflection;

namespace SparkEquation.Trial.WebAPI.UnitTests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Create_WhenModelIsNotValid_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);
            controller.ModelState.AddModelError("CategoryProducts", "CategoryProductsValidation");
            var product = new Product();
    
            // Act
            var result = (JsonResult)controller.Create(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }

        [TestMethod]
        public void Create_WhenModelIsValid_SuccessMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);
            var product = new Product();

            // Act
            var result = (JsonResult)controller.Create(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("True", successResult);
        }


        [TestMethod]
        public void Create_WhenServiceErrorRaised_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock(() => throw new Exception());
            var controller = new ProductController(productsService);
            var product = new Product();

            // Act
            var result = (JsonResult)controller.Create(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }


        [TestMethod]
        public void Update_WhenModelIsNotValid_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);
            controller.ModelState.AddModelError("CategoryProducts", "CategoryProductsValidation");
            var product = new Product();

            // Act
            var result = (JsonResult)controller.Update(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }

        [TestMethod]
        public void Update_WhenModelIsValid_SuccessMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);
            var product = new Product();

            // Act
            var result = (JsonResult)controller.Update(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("True", successResult);
        }

        [TestMethod]
        public void Update_WhenServiceErrorRaised_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock(() => throw new Exception());
            var controller = new ProductController(productsService);
            var product = new Product();

            // Act
            var result = (JsonResult)controller.Create(product);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }


        [TestMethod]
        public void Delete_WhenDelitionSucceed_SuccessMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Delete(1);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("True", successResult);
        }

        [TestMethod]
        public void Delete_WhenServiceErrorRaised_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock(() => throw new Exception());
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Delete(1);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }

        [TestMethod]
        public void Get_WhenGettingSucceed_SuccessMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Get(1);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("True", successResult);
        }

        [TestMethod]
        public void Get_WhenServiceErrorRaised_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock(() => throw new Exception());
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Get(1);
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }

        [TestMethod]
        public void GetAll_WhenGettingSucceed_SuccessMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock();
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Get();
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("True", successResult);
        }

        [TestMethod]
        public void GetAll_WhenServiceErrorRaised_ErrorMessageReceived()
        {
            // Arrange
            var productsService = MockFactory.CreateMock(() => throw new Exception());
            var controller = new ProductController(productsService);

            // Act
            var result = (JsonResult)controller.Get();
            var successResult = this.GetResponseResult(result);

            // Assert
            Assert.AreEqual("False", successResult);
        }

        private string GetResponseResult(JsonResult result)
        {
            var successProperty = result.Value.GetType().GetProperty("Success", BindingFlags.Instance | BindingFlags.Public);
            return successProperty.GetValue(result.Value, null).ToString();
        }
    }
}
