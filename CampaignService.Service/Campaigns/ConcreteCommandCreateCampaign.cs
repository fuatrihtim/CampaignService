using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Campaigns
{
    public class ConcreteCommandCreateCampaign : CommandCampaign
    {
        public ConcreteCommandCreateCampaign(Campaign campaign) : base(campaign)
        {
        }

        public override object Execute()
        {
            var createCampaignResult = _campaign.CreateCampaign(_campaign.Name, _campaign.ProductCode, _campaign.Hour, _campaign.PriceManipulationLimit, _campaign.TargetSalesCount);

            Console.WriteLine($"Campaign created; name { createCampaignResult.Name }, product { createCampaignResult.ProductCode }, duration { createCampaignResult.Hour }, limit { createCampaignResult.PriceManipulationLimit }, target sales count { createCampaignResult.TargetSalesCount }");

            return createCampaignResult;
        }
    }
}
