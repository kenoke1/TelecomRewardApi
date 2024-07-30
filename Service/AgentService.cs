
using Microsoft.EntityFrameworkCore;
using TelecomRewardsApi.Data;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public class AgentService : IAgentService
    {
        private readonly CampaignContext _context;

        public AgentService(CampaignContext context)
        {
            _context = context;
        }

        public async Task<bool> RewardCustomerAsync(int agentId, int customerId, string rewardDescription)
        {
            var agent = await _context.Agents.FindAsync(agentId);
            if (agent == null || !await CanRewardTodayAsync(agentId))
            {
                return false;
            }

            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return false;
            }

            agent.RewardsGivenToday++;
            var reward = new Reward
            {
                AgentId = agentId,
                CustomerId = customerId,
                RewardDescription = rewardDescription,
                RewardDate = DateTime.UtcNow
            };

            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> CanRewardTodayAsync(int agentId)
        {
            var today = DateTime.UtcNow.Date;
            var rewardsGivenToday = await _context.Rewards
                .CountAsync(r => r.AgentId == agentId && r.RewardDate.Date == today);

            return rewardsGivenToday < 5;
        }
    }
}
