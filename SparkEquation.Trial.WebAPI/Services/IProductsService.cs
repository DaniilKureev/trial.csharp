using System.Collections.Generic;
using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public interface IProductsService
    {
        List<Product> GetAllProductsData();
        Product GetProduct(int id);
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}