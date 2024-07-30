namespace TelecomRewardsApi.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DailyRewardsLimt { get; set; } = 5;
        public int RewardsGivenToday { get; set; }
        public ICollection<Reward> Rewards { get; set; }
    }
}
