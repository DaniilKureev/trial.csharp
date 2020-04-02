using SparkEquation.Trial.WebAPI.Services;
using System;

namespace SparkEquation.Trial.WebAPI.UnitTests.Mocks
{
    public class MockFactory
    {
        public static IProductsService CreateMock(Action precallAction = null) 
        {
            return new ProductsServiceMock(precallAction);
        }
    }
}
