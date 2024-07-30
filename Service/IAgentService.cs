namespace TelecomRewardsApi.Service
{
    public interface IAgentService
    {
        Task<bool> RewardCustomerAsync(int agentId, int customerId, string rewardDescription);
    }
}
