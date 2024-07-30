using TelecomRewardsApi.Models;

namespace TelecomRewardsApi.Service
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
