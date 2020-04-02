using SparkEquation.Trial.WebAPI.Data.Factory;
using SparkEquation.Trial.WebAPI.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SparkEquation.Trial.WebAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IContextFactory _factory;
        private readonly IProductProcessor productProcessor;

        public ProductsService(IContextFactory contextFactory, IProductProcessor productProcessor)
        {
            _factory = contextFactory;
            this.productProcessor = productProcessor;
        }

        public List<Product> GetAllProductsData()
        {
            using (var context = _factory.GetContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (var context = _factory.GetContext())
            {
                return context.Products.FirstOrDefault(o => o.Id == id);
            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = _factory.GetContext())
            {
                this.productProcessor.AdjustProductToFeatured(product);
                context.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = _factory.GetContext())
            {
                this.productProcessor.AdjustProductToFeatured(product);
                context.Update(product);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var context = _factory.GetContext())
            {
                var storedProduct = context.Products.FirstOrDefault(o => o.Id == id);

                if (storedProduct == null)
                    throw new System.Exception("Error while deleting product. Wrong product id");
               
                context.Remove(storedProduct);
                context.SaveChanges();
            }
        }
    }
}