using CampaignService.Domain.Entities;
using CampaignService.Domain.Enums;
using NUnit.Framework;

namespace CampaignService.Tests
{
    [TestFixture]
    public class OrderTest
    {
        private Product product = null;
        private Campaign campaign = null;
        private Order order = null;

        [SetUp]
        public void SetupOrder()
        {
            product = new Product("TestCode", 20, 500);
            campaign = new Campaign("TestCampaign", "TestCode", 1, 10, 200, CampaignStatus.Active);
            order = new Order(product, campaign, 10);
        }

        [Test]
        public void CreateOrder_Success()
        {
            var newOrder = order.CreateOrder(product.ProductCode, order.Quantity);

            Assert.AreEqual(true, newOrder.Item3);

        }
    }
}
