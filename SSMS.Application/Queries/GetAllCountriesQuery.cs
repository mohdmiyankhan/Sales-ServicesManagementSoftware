using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllCountriesQuery() : IRequest<ApiResponseModel<IEnumerable<CountryEntity>>>;

    public class GetAllCountriesQueryHandler(ICountryRepository countryRepository)
        : IRequestHandler<GetAllCountriesQuery, ApiResponseModel<IEnumerable<CountryEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<CountryEntity>>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await countryRepository.GetAllCountriesAsync();
        }
    }
}
