namespace TelecomRewardsApi.Service
{
    public interface IAuthService
    {
        string GenerateToken(string username);
    }
}
