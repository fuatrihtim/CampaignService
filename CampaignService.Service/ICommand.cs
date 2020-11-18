using System.Collections.Generic;

namespace CampaignService.Service
{
    public interface ICommand
    {
        Dictionary<object, string> ExecuteCommand(object obj, string command);
    }
}
