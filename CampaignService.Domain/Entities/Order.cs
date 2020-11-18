using CampaignService.Domain.Enums;

namespace CampaignService.Domain.Entities
{
    public class Order
    {
        public Product Product { get; set; }

        public Campaign Campaign { get; set; }

        public int OrderNumber { get; set; }

        public int Quantity { get; set; }

        public Order(Product product, Campaign campaign, int quantity)
        {
            this.Product = product;
            this.Campaign = campaign;
            this.Quantity = quantity;
            this.OrderNumber = OrderNumber + 1;
        }

        public (Product, int, bool) CreateOrder(string productCode, int quantity)
        {
            bool isSuccess = false;

            if (Product.Stock > quantity)
            {
                Product.Stock = Product.Stock - quantity;

                if (Campaign.ProductCode == productCode && Campaign.CampaignStatus == CampaignStatus.Active && Campaign.TargetSalesCount > Campaign.TotalSalesCount)
                {
                    Campaign.TotalSalesCount = Campaign.TotalSalesCount + quantity;
                    Campaign.Turnover = Product.Price * quantity;
                }

                isSuccess = true;
            }

            return (Product, quantity, isSuccess);
        }
    }
}
