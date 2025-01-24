using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetCountryByIdQuery(int countryId) : IRequest<ApiResponseModel<CountryEntity>>;

    public class GetCountryByIdQueryHandler(ICountryRepository countryRepository)
        : IRequestHandler<GetCountryByIdQuery, ApiResponseModel<CountryEntity>>
    {
        public async Task<ApiResponseModel<CountryEntity>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            return await countryRepository.GetCountryByIdAsync(request.countryId);
        }
    }
}
