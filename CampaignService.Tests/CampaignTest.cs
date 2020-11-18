using CampaignService.Domain.Entities;
using CampaignService.Domain.Enums;
using NUnit.Framework;

namespace CampaignService.Tests
{
    [TestFixture]
    public class CampaignTest
    {
        private Campaign campaign = null;

        [SetUp]
        public void SetupActiveCampaign()
        {
            campaign = new Campaign("TestCampaign", "TestCode", 1, 10, 500, CampaignStatus.Active);
        }

        [Test]
        public void CreateCampaign_Success()
        {
            var newCampaign = campaign.CreateCampaign(campaign.Name, campaign.ProductCode, campaign.Hour, campaign.PriceManipulationLimit, campaign.TargetSalesCount);

            Assert.AreEqual(campaign.Name, newCampaign.Name);
            Assert.AreEqual(campaign.ProductCode, newCampaign.ProductCode);
            Assert.AreEqual(campaign.Hour, newCampaign.Hour);
            Assert.AreEqual(campaign.PriceManipulationLimit, newCampaign.PriceManipulationLimit);
            Assert.AreEqual(campaign.TargetSalesCount, newCampaign.TargetSalesCount);
        }

        [Test]
        public void GetCampaignInfo_Success()
        {
            var campaignInfo = campaign.GetCampaignInfo(campaign.Name);

            Assert.AreEqual(campaign.Name, campaignInfo.Item1);
            Assert.AreEqual(campaign.CampaignStatus, campaignInfo.Item2);
            Assert.AreEqual(campaign.TargetSalesCount, campaignInfo.Item3);
            Assert.AreEqual(campaign.Turnover, campaignInfo.Item4);
            Assert.AreEqual(campaign.TotalSalesCount, campaignInfo.Item5);
        }

        [Test]
        public void IncreaseTime_Success()
        {
            string time = campaign.IncreaseTime(1);

            Assert.AreEqual("01:00", time);
        }
    }
}
