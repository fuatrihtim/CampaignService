using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Products
{
    public class ConcreteCommandGetProductInfo : CommandProduct
    {
        public ConcreteCommandGetProductInfo(Product product) : base(product)
        {
        }

        public override object Execute()
        {
            var getProductInfoResult = _product.GetProductInfo(_product.ProductCode);

            Console.WriteLine($"Product { getProductInfoResult.Item1 } info; price { getProductInfoResult.Item2 }, stock { getProductInfoResult.Item3 }");

            return getProductInfoResult;
        }
    }
}
