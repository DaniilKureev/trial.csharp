using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public class ProductProcessor : IProductProcessor
    {
        public void AdjustProductToFeatured(Product product)
        {
            if (product.Rating > Consts.RaitingBoundValue)
                product.Featured = true;
        }
    }
}
