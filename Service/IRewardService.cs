using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public interface IRewardService
    {
        Task<Reward> RewardCustomerAsync(int agentId, int customerId, string rewardDescription);
        Task<Reward> CreateRewardAsync(Reward reward);
        Task<Reward> GetRewardByIdAsync(int id);
        Task<IEnumerable<Reward>> GetAllRewardsAsync();
    }
}
