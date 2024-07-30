namespace TelecomRewardsApi.Models
{
    public class RewardRequest
    {
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public string RewardDescription { get; set; }
    }
}
