namespace TelecomRewardsApi.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }
    }
}
