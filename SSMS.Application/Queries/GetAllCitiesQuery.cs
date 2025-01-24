using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllCitiesQuery() : IRequest<ApiResponseModel<IEnumerable<CityEntity>>>;

    public class GetAllCitiesQueryHandler(ICityRepository cityRepository)
        : IRequestHandler<GetAllCitiesQuery, ApiResponseModel<IEnumerable<CityEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<CityEntity>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            return await cityRepository.GetAllCitiesAsync();
        }
    }
}
