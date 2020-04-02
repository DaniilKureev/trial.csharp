using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;

namespace SparkEquation.Trial.WebAPI.UnitTests.Mocks
{
    public class ProductsServiceMock : IProductsService
    {
        private readonly Action preCallAction;

        public ProductsServiceMock(Action preCallAction)
        {
            this.preCallAction = preCallAction;
        }

        public void DeleteProduct(int id)
        {
            if (preCallAction != null)
                this.preCallAction();

            return;
        }

        public List<Product> GetAllProductsData()
        {
            if (preCallAction != null)
                this.preCallAction();

            return null;
        }

        public Product GetProduct(int id)
        {
            if (preCallAction != null)
                this.preCallAction();

            return null;
        }

        public void SaveProduct(Product product)
        {
            if (preCallAction != null)
                this.preCallAction();

            return;
        }

        public void UpdateProduct(Product product)
        {
            if (preCallAction != null)
                this.preCallAction();

            return;
        }
    }
}
