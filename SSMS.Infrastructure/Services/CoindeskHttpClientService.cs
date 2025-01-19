using SSMS.Core.Models;
using System.Net.Http.Json;

namespace SSMS.Infrastructure.Services
{
    public class CoindeskHttpClientService(HttpClient httpClient) : ICoindeskHttpClientService
    {
        public async Task<CoindeskDataModel> GetData()
        {
            return await httpClient.GetFromJsonAsync<CoindeskDataModel>("bpi/currentprice.json");
        }
    }
}
