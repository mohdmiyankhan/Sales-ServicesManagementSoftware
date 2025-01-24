using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetCityByIdQuery(int cityId) : IRequest<ApiResponseModel<CityEntity>>;

    public class GetCityByIdQueryHandler(ICityRepository cityRepository)
        : IRequestHandler<GetCityByIdQuery, ApiResponseModel<CityEntity>>
    {
        public async Task<ApiResponseModel<CityEntity>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            return await cityRepository.GetCityByIdAsync(request.cityId);
        }
    }
}
