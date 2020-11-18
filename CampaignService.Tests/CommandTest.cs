using CampaignService.Domain.Entities;
using CampaignService.Domain.Enums;
using CampaignService.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignService.Tests
{
    [TestFixture]
    public class CommandTest
    {
        private ICommand instance = null;
        private Invoker invoker = null;

        private Product product = null;
        private Campaign campaign = null;
        private Order order = null;

        [SetUp]
        public void SetupCommands()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\FUAT\Desktop\Scenario1 (4).txt");

            var classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(ICommand).IsAssignableFrom(x) && x.Name != "ICommand");
            instance = (ICommand)Activator.CreateInstance(classList.First());

            invoker = new Invoker();
            product = new Product("TestCode", 20, 500);
            campaign = new Campaign("TestCampaign", "TestCode", 1, 10, 500, CampaignStatus.Active);
            order = new Order(product, campaign, 10);
        }

        [Test]
        public void CreateProduct_Command_Success()
        {
            invoker.CommandList = instance.ExecuteCommand(product, "create_product");
            invoker.ExecuteAll();

            Assert.AreEqual("TestCode", product.ProductCode);
        }

        [Test]
        public void CreateOrder_Command_Success()
        {
            invoker.CommandList = instance.ExecuteCommand(order, "create_order");
            invoker.ExecuteAll();

            Assert.AreEqual(500 - order.Quantity, product.Stock);
        }
    }
}
