using Microsoft.EntityFrameworkCore;
using TelecomRewardsApi.Data;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public class RewardService : IRewardService //IRewardService
    {
        private readonly CampaignContext _context;

        public RewardService(CampaignContext context)
        {
            _context = context;
        }

        public async Task<Reward> CreateRewardAsync(Reward reward)
        {
            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();
            return reward;
        }

        public async Task<IEnumerable<Reward>> GetAllRewardsAsync()
        {
            return await _context.Rewards.ToListAsync();
        }

        public async Task<Reward> GetRewardByIdAsync(int id)
        {
            return await _context.Rewards.FindAsync(id);
        }



        public async Task<Reward> RewardCustomerAsync(int agentId, int customerId, string rewardDescription)
        {
            var agent = await _context.Agents
                .Include(a => a.Rewards)
                .FirstOrDefaultAsync(a => a.Id == agentId);

            if (agent == null)
                throw new Exception("Agent not found");

            var todayRewards = agent.Rewards.Count(r => r.RewardDate.Date == DateTime.Today);
            if (todayRewards >= agent.DailyRewardsLimt)
                throw new Exception("Daily reward limit reached");

            var reward = new Reward
            {
                AgentId = agentId,
                CustomerId = customerId,
                RewardDescription = rewardDescription,
                RewardDate = DateTime.UtcNow
            };

            _context.Rewards.Add(reward);
            await _context.SaveChangesAsync();

            return reward;
        }
    }
}
