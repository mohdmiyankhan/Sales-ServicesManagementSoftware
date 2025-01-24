using Microsoft.EntityFrameworkCore;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;
using SSMS.Infrastructure.Data;

namespace SSMS.Infrastructure.Repositories
{
    public class CountryRepository(SSMSDbContext dbContext) : ICountryRepository
    {
        public async Task<ApiResponseModel<IEnumerable<CountryEntity>>> GetAllCountriesAsync()
        {
            IQueryable<CountryEntity> countriesQ = dbContext.CountryMaster;
            IEnumerable<CountryEntity> countriesE = await countriesQ.Where(x => x.IsActive == 1).ToListAsync();

            if (countriesE.Any())
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CountryEntity>>
                {
                    Message = "Country list fetched successfully.",
                    Status = 200,
                    Data = countriesE
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<IEnumerable<CountryEntity>>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CountryEntity>> GetCountryByIdAsync(int countryId)
        {
            var country = await dbContext.CountryMaster.FirstOrDefaultAsync(x => x.Id == countryId);
            if (country is not null)
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Country fetched successfully.",
                    Status = 200,
                    Data = country
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Record not found.",
                    Status = 404
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CountryEntity>> AddCountryAsync(CountryEntity entity)
        {
            //entity.Id = Guid.NewGuid();
            entity.CreatedBy = null;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedBy = null;
            entity.ModifiedDate = null;
            entity.DeletedBy = null;
            entity.DeletedDate = null;
            entity.IsActive = 1;

            dbContext.CountryMaster.Add(entity);
            int res = await dbContext.SaveChangesAsync();
            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Country added successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CountryEntity>> UpdateCountryAsync(int countryId, CountryEntity entity)
        {
            int res = 0;
            var country = await dbContext.CountryMaster.FirstOrDefaultAsync(x => x.Id == countryId);
            if (country is not null)
            {
                country.Country = entity.Country;
                country.ModifiedBy = null;
                country.ModifiedDate = DateTime.UtcNow;

                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Country updated successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }

        public async Task<ApiResponseModel<CountryEntity>> DeleteCountryAsync(int countryId)
        {
            int res = 0;
            var country = await dbContext.CountryMaster.FirstOrDefaultAsync(x => x.Id == countryId);
            if (country is not null)
            {
                country.DeletedBy = null;
                country.DeletedDate = DateTime.UtcNow;
                country.IsActive = 0;

                //dbContext.CountryMaster.Remove(country);
                res = await dbContext.SaveChangesAsync();
            }

            if (res > 0)
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Country deleted successfully.",
                    Status = 200
                };
                return response;
            }
            else
            {
                // Create Api response
                var response = new ApiResponseModel<CountryEntity>
                {
                    Message = "Some error occurd.",
                    Status = 400
                };
                return response;
            }
        }
    }
}
