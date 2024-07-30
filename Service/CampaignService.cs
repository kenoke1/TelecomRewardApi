using Microsoft.EntityFrameworkCore;
using TelecomRewardsApi.Data;
using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignContext _context;

        public CampaignService(CampaignContext context)
        {
            _context = context;
        }

        public async Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }

        public async Task DeleteCampaignAsync(int id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Campaign>> GetAllCampaignsAsync()
        {
            return await _context.Campaigns.ToListAsync();
        }

        public async Task<Campaign> GetCampaignByIdAsync(int id)
        {
            return await _context.Campaigns.FindAsync(id);
        }

        public async Task<Campaign> UpdateCampaignAsync(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync();
            return campaign;
        }
    }
}
