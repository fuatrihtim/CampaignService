using CampaignService.Domain.Entities;
using NUnit.Framework;

namespace CampaignService.Tests
{
    [TestFixture]
    public class ProductTest
    {
        private Product product = null;

        [SetUp]
        public void SetupProduct()
        {
            product = new Product("TestCode", 20, 500);
        }

        [Test]
        public void CreateProduct_Success()
        {
            var newProduct = product.CreateProduct(product.ProductCode, product.Price, product.Stock);

            Assert.AreEqual(product.ProductCode, newProduct.Item1);
            Assert.AreEqual(product.Price, newProduct.Item2);
            Assert.AreEqual(product.Stock, newProduct.Item3);
        }

        [Test]
        public void GetProductInfo_Success()
        {
            var productInfo = product.GetProductInfo(product.ProductCode);

            Assert.AreEqual(product.ProductCode, productInfo.Item1);
            Assert.AreEqual(product.Price, productInfo.Item2);
            Assert.AreEqual(product.Stock, productInfo.Item3);
        }
    }
}
