using CampaignService.Domain.Entities;

namespace CampaignService.Service.Products
{
    public abstract class CommandProduct
    {
        public Product _product;

        public CommandProduct(Product product)
        {
            this._product = product;
        }

        public abstract object Execute();
    }
}
