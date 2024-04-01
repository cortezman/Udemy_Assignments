using ServiceContracts;
using System.Text.Json;
using Microsoft.Extensions.Configuration;


namespace Services
{
    public class FinnHubService : IFinnHubService
    {

        private readonly IHttpClientFactory _httpClientFactory;

    }
}
