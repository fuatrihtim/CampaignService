using CampaignService.Domain.Entities;
using CampaignService.Program.Extensions;
using CampaignService.Service;
using System;
using System.Linq;

namespace CampaignService.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\FUAT\Desktop\Scenario1 (4).txt");

            var classList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(ICommand).IsAssignableFrom(x) && x.Name != "ICommand");
            ICommand instance = (ICommand)Activator.CreateInstance(classList.First());

            Invoker invoker = new Invoker();
            Product product = null;
            Campaign campaign = null;
            Order order = null;

            foreach (string commandLine in lines)
            {
                string[] splittedCommand = commandLine.Split(' ');

                switch (splittedCommand[0])
                {
                    case "create_product":

                        product = commandLine.ToProductEntity();
                        invoker.CommandList = instance.ExecuteCommand(product, splittedCommand.First());

                        break;
                    case "get_product_info":

                        invoker.CommandList = instance.ExecuteCommand(product, splittedCommand.First());

                        break;
                    case "create_order":

                        order = commandLine.ToOrderEntity(product, campaign);
                        invoker.CommandList = instance.ExecuteCommand(order, splittedCommand.First());

                        break;
                    case "create_campaign":

                        campaign = commandLine.ToCampaignEntity();
                        invoker.CommandList = instance.ExecuteCommand(campaign, splittedCommand.First());

                        break;
                    case "get_campaign_info":
                    case "increase_time":

                        invoker.CommandList = instance.ExecuteCommand(campaign, splittedCommand.First());

                        break;
                    default:
                        break;
                }
            }

            invoker.ExecuteAll();

            Console.ReadKey();
        }
    }
}