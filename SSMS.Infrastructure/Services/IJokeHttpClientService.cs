using SSMS.Core.Models;

namespace SSMS.Infrastructure.Services
{
    public interface IJokeHttpClientService
    {
        Task<JokeModel> GetData();
    }
}