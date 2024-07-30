namespace TelecomRewardsApi.Service
{
    public interface ISoapClientService
    {
        Task<string> FindPersonAsync(string id);
    }
}
