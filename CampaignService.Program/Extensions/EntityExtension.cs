using CampaignService.Domain.Entities;
using System;

namespace CampaignService.Program.Extensions
{
    public static class EntityExtension
    {
        public static Product ToProductEntity(this string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;

            string[] splittedCommand = command.Split(' ');

            return new Product(splittedCommand[1], Convert.ToDecimal(splittedCommand[2]), Convert.ToInt32(splittedCommand[3]));
        }

        public static Order ToOrderEntity(this string command, Product product, Campaign campaign)
        {
            if (string.IsNullOrEmpty(command))
                return null;

            string[] splittedCommand = command.Split(' ');

            return new Order(product, campaign, command[1]);
        }

        public static Campaign ToCampaignEntity(this string command)
        {
            if (string.IsNullOrEmpty(command))
                return null;

            string[] splittedCommand = command.Split(' ');

            return new Campaign(splittedCommand[1], splittedCommand[2], Convert.ToInt32(splittedCommand[3]), Convert.ToInt32(splittedCommand[4]), Convert.ToInt32(splittedCommand[5]), Domain.Enums.CampaignStatus.Active);
        }
    }
}