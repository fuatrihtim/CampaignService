using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Campaigns
{
    public class ConcreteCommandGetCampaignInfo : CommandCampaign
    {
        public ConcreteCommandGetCampaignInfo(Campaign campaign) : base(campaign)
        {
        }

        public override object Execute()
        {
            var getCampaignInfoResult = _campaign.GetCampaignInfo(_campaign.Name);

            Console.WriteLine($"Campaign { _campaign.Name } info; Status { getCampaignInfoResult.Item2 }, Target Sales { getCampaignInfoResult.Item3 }, Total Sales { getCampaignInfoResult.Item5 }, Turnover { getCampaignInfoResult.Item4 }, Average Item Price { getCampaignInfoResult.Item4 / getCampaignInfoResult.Item5 }");

            return getCampaignInfoResult;
        }
    }
}
