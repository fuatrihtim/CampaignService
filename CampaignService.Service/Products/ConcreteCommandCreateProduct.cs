using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Products
{
    public class ConcreteCommandCreateProduct : CommandProduct
    {
        public ConcreteCommandCreateProduct(Product product) : base(product)
        {
        }

        public override object Execute()
        {
            var createProductResult = _product.CreateProduct(_product.ProductCode, _product.Price, _product.Stock);

            Console.WriteLine($"Product created; code { createProductResult.Item1 }, price { createProductResult.Item2 }, stock { createProductResult.Item3 }");

            return createProductResult;
        }
    }
}
