namespace TelecomRewardsApi.Service
{
    public interface ICsvService
    {
        Task<string> GenerateCsvReportAsync();
    }
}
