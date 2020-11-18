using CampaignService.Domain.Enums;
using System;

namespace CampaignService.Domain.Entities
{
    public class Campaign
    {
        public string Name { get; set; }

        public string ProductCode { get; set; }

        //Duration is given in hours.
        public int Hour { get; set; }

        //A price manipulation limit is the maximum percentage that you can increase or decrease the price of product according to demand.
        public int PriceManipulationLimit { get; set; }

        //Target sales count is the product quantity you want to sell during the campaign.
        public int TargetSalesCount { get; set; }

        public int TotalSalesCount { get; set; }

        public decimal Turnover { get; set; }

        public CampaignStatus CampaignStatus { get; set; }

        public Campaign(string name, string productCode, int hour, int priceManipulationLimit, int targetSalesCount, CampaignStatus campaignStatus)
        {
            this.Name = name;
            this.ProductCode = productCode;
            this.Hour = hour;
            this.PriceManipulationLimit = priceManipulationLimit;
            this.TargetSalesCount = targetSalesCount;
            this.CampaignStatus = campaignStatus;
        }

        public Campaign CreateCampaign(string name, string productCode, int duration, int pmLimit, int targetSalesCount)
        {
            return new Campaign(name, ProductCode, duration, pmLimit, targetSalesCount, CampaignStatus.Active);
        }

        public (string, CampaignStatus, int, decimal, int) GetCampaignInfo(string name)
        {
            return (Name, CampaignStatus, TargetSalesCount, Turnover, TotalSalesCount);
        }

        public string IncreaseTime(int hour)
        {
            TimeSpan hourTime = TimeSpan.FromHours(hour);
            string hourString = hourTime.ToString("hh':'mm");

            return hourString;
        }
    }
}