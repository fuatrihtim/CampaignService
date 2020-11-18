using CampaignService.Service.Campaigns;
using CampaignService.Service.Orders;
using CampaignService.Service.Products;
using System.Collections.Generic;

namespace CampaignService.Service
{
    public class Invoker
    {
        public Dictionary<object, string> CommandList { get; set; }

        public Invoker()
        {
            CommandList = new Dictionary<object, string>();
        }

        public void ExecuteAll()
        {
            if (CommandList.Count == 0)
                return;

            foreach (KeyValuePair<object, string> item in CommandList)
            {
                switch (item.Value)
                {
                    case "create_product":
                    case "get_product_info":

                        var commandProduct = (CommandProduct)item.Key;
                        var result = commandProduct.Execute();

                        break;
                    case "create_order":

                        var commandOrder = (CommandOrder)item.Key;
                        commandOrder.Execute();

                        break;
                    case "create_campaign":
                    case "get_campaign_info":
                    case "increase_time":

                        var commandCampaign = (CommandCampaign)item.Key;
                        commandCampaign.Execute();

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
