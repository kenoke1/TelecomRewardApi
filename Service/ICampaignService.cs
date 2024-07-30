using TelecomRewardsApi.Data;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public interface ICampaignService
    {
        Task<Campaign> CreateCampaignAsync(Campaign campaign);
        Task<Campaign> GetCampaignByIdAsync(int id);
        Task<IEnumerable<Campaign>> GetAllCampaignsAsync();
        Task<Campaign> UpdateCampaignAsync(Campaign campaign);
        Task DeleteCampaignAsync(int id);
    }
}
