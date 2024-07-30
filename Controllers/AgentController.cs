using Microsoft.AspNetCore.Mvc;
using TelecomRewardsApi.Service;

namespace TelecomRewardsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpPost("{agentId}/reward/{customerId}")]
        public async Task<IActionResult> RewardCustomer(int agentId, int customerId, [FromBody] string rewardDescription)
        {
            var result = await _agentService.RewardCustomerAsync(agentId, customerId, rewardDescription);
            if (!result)
            {
                return BadRequest("Could not reward customer. Either the agent has reached the daily limit or the customer does not exist.");
            }
            return Ok("Customer rewarded successfully.");
        }
    }
}
