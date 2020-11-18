using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Campaigns
{
    public class ConcreteCommandIncreaseTime : CommandCampaign
    {
        public ConcreteCommandIncreaseTime(Campaign campaign) : base(campaign)
        {
        }

        public override object Execute()
        {
            var increaseTimeResult = _campaign.IncreaseTime(1);

            Console.WriteLine($"Time is { increaseTimeResult }");

            return increaseTimeResult;
        }
    }
}
