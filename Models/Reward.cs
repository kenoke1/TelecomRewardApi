using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TelecomRewardsApi.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AgentId { get; set; }
        public DateTime RewardDate {  get; set; }
        public string RewardDescription { get; set; }
        public Agent Agent { get; set; }
        public Customer Customer {  get; set; }
    }
}
