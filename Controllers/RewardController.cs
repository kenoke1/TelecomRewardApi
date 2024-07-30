using Microsoft.AspNetCore.Mvc;
using TelecomRewardsApi.Models;
using TelecomRewardsApi.Service;

namespace TelecomRewardsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _rewardService;

        public RewardController(IRewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpPost]
        public async Task<IActionResult> RewardCustomer([FromBody] RewardRequest rewardRequest)
        {
            try
            {
                var reward = await _rewardService.RewardCustomerAsync(rewardRequest.AgentId, rewardRequest.CustomerId, rewardRequest.RewardDescription);
                return Ok(reward);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
