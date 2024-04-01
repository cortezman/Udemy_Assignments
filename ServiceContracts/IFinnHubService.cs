namespace ServiceContracts
{
    public interface IFinnHubService
    {
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol);
        Task<Dictionary<string, object>?> GetStockPriceQoute(string stockSymbol);
    }
}
