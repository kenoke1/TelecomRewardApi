using CrmService;

namespace TelecomRewardsApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public ICollection<Reward> Rewards { get; set; }

    }
}
