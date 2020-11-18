using CampaignService.Domain.Entities;

namespace CampaignService.Service.Campaigns
{
    public abstract class CommandCampaign
    {
        public Campaign _campaign;

        public CommandCampaign(Campaign campaign)
        {
            this._campaign = campaign;
        }

        public abstract object Execute();
    }
}