using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Service.Orders
{
    public class ConcreteCommandCreateOrder : CommandOrder
    {
        public ConcreteCommandCreateOrder(Order order) : base(order)
        {
        }

        public override object Execute()
        {
            var createOrderResult = _order.CreateOrder(_order.Product.ProductCode, _order.Quantity);

            if (createOrderResult.Item3)
            {
                Console.WriteLine($"Order created; product { createOrderResult.Item1.ProductCode }, quantity  { createOrderResult.Item2 }");
            }
            else
            {
                Console.WriteLine($"Order error. Stock quantity is not sufficient!");
            }

            return createOrderResult;
        }
    }
}
