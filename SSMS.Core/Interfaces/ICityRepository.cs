using SSMS.Core.Entities;
using SSMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Core.Interfaces
{
    public interface ICityRepository
    {
        Task<ApiResponseModel<IEnumerable<CityEntity>>> GetAllCitiesAsync();
        Task<ApiResponseModel<CityEntity>> GetCityByIdAsync(int cityId);
        Task<ApiResponseModel<CityEntity>> AddCityAsync(CityEntity entity);
        Task<ApiResponseModel<CityEntity>> UpdateCityAsync(int cityId, CityEntity entity);
        Task<ApiResponseModel<CityEntity>> DeleteCityAsync(int cityId);
    }
}
