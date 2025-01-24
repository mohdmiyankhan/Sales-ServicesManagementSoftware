using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Infrastructure.Repositories
{
    public class CityRepository(SSMSDbContext dbContext) : ICityRepository
    {
        public async Task<ApiResponseModel<IEnumerable<CityEntity>>> GetAllCitiesAsync()
        {
            IQueryable<CityEntity> query = from city in dbContext.CityMaster
                                           join country in dbContext.CountryMaster
                                           on city.CountryId equals country.Id
                                           where city.IsActive == 1
                                           select new CityEntity
                                           {
                                               Id = city.Id,
                                               City = city.City,
                                               Country = country.Country,
                                               CountryId = country.Id,
                                               DefaultSetting = city.DefaultSetting,
                                               CreatedBy = city.CreatedBy,
                                               CreatedDate = city.CreatedDate,
                                               ModifiedBy = city.ModifiedBy,
                                               ModifiedDate = city.ModifiedDate,
                                               DeletedBy = city.DeletedBy,
                                               DeletedDate = city.DeletedDate,
                                               IsActive = city.IsActive,
                                           };
            var cities = await query.ToListAsync();

            if (cities.Count > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CityEntity>>
                {
                    Message = "City list fetched successfully.",
                    Status = 200,
                    Data = cities
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CityEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CityEntity>> GetCityByIdAsync(int cityId)
        {
            var city = await dbContext.CityMaster.FirstOrDefaultAsync(x => x.Id == cityId);
            if (city is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "City fetched successfully.",
                    Status = 200,
                    Data = city
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CityEntity>> AddCityAsync(CityEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.CityMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "City added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CityEntity>> UpdateCityAsync(int cityId, CityEntity entity)
        {
            int res = 0;
            var city = await dbContext.CityMaster.FirstOrDefaultAsync(x => x.Id == cityId);
            if (city is not null)
            {
                city.City = entity.City;
                city.CountryId = entity.CountryId;
                city.DefaultSetting = entity.DefaultSetting;
                city.ModifiedBy = null;
                city.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "City updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CityEntity>> DeleteCityAsync(int cityId)
        {
            int res = 0;
            var city = await dbContext.CityMaster.FirstOrDefaultAsync(x => x.Id == cityId);
            if (city is not null)
            {
                city.DeletedBy = null;
                city.DeletedDate = DateTime.UtcNow;
                city.IsActive = 0;

                //dbContext.CityMaster.Remove(city);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "City deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CityEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}
