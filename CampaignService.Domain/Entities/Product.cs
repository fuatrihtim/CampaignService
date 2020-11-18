namespace CampaignService.Domain.Entities
{
    public class Product
    {
        public string ProductCode { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public Product(string productCode, decimal price, int stock)
        {
            this.ProductCode = productCode;
            this.Price = price;
            this.Stock = stock;
        }

        public (string, decimal, int) CreateProduct(string productCode, decimal price, int stock)
        {
            return (ProductCode, Price, Stock);
        }

        public (string, decimal, int) GetProductInfo(string productCode)
        {
            return (ProductCode, Price, Stock);
        }
    }
}
