using SSMS.Core.Entities;
using SSMS.Core.Models;

namespace SSMS.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<ApiResponseModel<IEnumerable<CountryEntity>>> GetAllCountriesAsync();
        Task<ApiResponseModel<CountryEntity>> GetCountryByIdAsync(int countryId);
        Task<ApiResponseModel<CountryEntity>> AddCountryAsync(CountryEntity entity);
        Task<ApiResponseModel<CountryEntity>> UpdateCountryAsync(int countryId, CountryEntity entity);
        Task<ApiResponseModel<CountryEntity>> DeleteCountryAsync(int countryId);
    }
}