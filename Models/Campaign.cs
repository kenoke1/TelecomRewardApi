namespace TelecomRewardsApi.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int DailyLimit { get; set; } = 5;
    }
}
