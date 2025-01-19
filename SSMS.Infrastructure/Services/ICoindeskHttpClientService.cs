using SSMS.Core.Models;

namespace SSMS.Infrastructure.Services
{
    public interface ICoindeskHttpClientService
    {
        Task<CoindeskDataModel> GetData();
    }
}