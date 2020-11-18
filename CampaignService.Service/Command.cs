using CampaignService.Domain.Entities;
using CampaignService.Service.Campaigns;
using CampaignService.Service.Orders;
using CampaignService.Service.Products;
using System.Collections.Generic;

namespace CampaignService.Service
{
    public class Command : ICommand
    {
        Dictionary<object, string> commandList = new Dictionary<object,string>();

        public Dictionary<object, string> ExecuteCommand(object obj, string command)
        {
            switch (command)
            {
                case "create_product":

                    commandList.Add(new ConcreteCommandCreateProduct((Product)obj), command);

                    break;
                case "get_product_info":

                    commandList.Add(new ConcreteCommandGetProductInfo((Product)obj), command);

                    break;
                case "create_order":

                    commandList.Add(new ConcreteCommandCreateOrder((Order)obj), command);

                    break;
                case "create_campaign":

                    commandList.Add(new ConcreteCommandCreateCampaign((Campaign)obj), command);

                    break;
                case "get_campaign_info":

                    commandList.Add(new ConcreteCommandGetCampaignInfo((Campaign)obj), command);

                    break;
                case "increase_time":

                    commandList.Add(new ConcreteCommandIncreaseTime((Campaign)obj), command);

                    break;
                default:
                    break;
            }

            return commandList;
        }
    }
}
