using CampaignService.Domain.Entities;

namespace CampaignService.Service.Orders
{
    public abstract class CommandOrder
    {
        public Order _order;

        public CommandOrder(Order order)
        {
            this._order = order;
        }

        public abstract object Execute();
    }
}
