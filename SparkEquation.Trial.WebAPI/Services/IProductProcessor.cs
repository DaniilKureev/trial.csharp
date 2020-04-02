using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public interface IProductProcessor
    {
        void AdjustProductToFeatured(Product product);
    }
}
