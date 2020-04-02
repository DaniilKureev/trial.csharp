using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;

namespace SparkEquation.Trial.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _productsService.GetAllProductsData();
                return this.CreateSuccesfullResponse(results);
            }
            catch (Exception ex)
            {
                return this.CreateErrorResponse(ex);
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _productsService.GetProduct(id);
                return this.CreateSuccesfullResponse(result);
            }
            catch (Exception ex)
            {
                return this.CreateErrorResponse(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            try
            {
                this.ValidateModel();

                _productsService.UpdateProduct(product);
                return this.CreateSuccesfullResponse();
            }
            catch (Exception ex)
            {
                return this.CreateErrorResponse(ex);
            }
        }

        [HttpPut]
        public IActionResult Create(Product product)
        {
            try
            {
                this.ValidateModel();

                 _productsService.SaveProduct(product);
                return this.CreateSuccesfullResponse();
            }
            catch (Exception ex)
            {
                return this.CreateErrorResponse(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _productsService.DeleteProduct(id);               
                return this.CreateSuccesfullResponse();
            }
            catch (Exception ex)
            {
                return this.CreateErrorResponse(ex);
            }
        }

        private void ValidateModel()
        {
            if (!ModelState.IsValid)
                throw new Exception("Invalid input product model");
        }

        private JsonResult CreateErrorResponse(Exception ex)
        {
            var message = ex.InnerException?.Message ?? ex.Message;

            return new JsonResult(new { Success = "False", ResponseText = message });
        }

        private JsonResult CreateSuccesfullResponse(object jsonData = null)
        {
            if(jsonData == null)
                return new JsonResult(new { Success = "True"});

            return new JsonResult(jsonData);
        }
    }
}