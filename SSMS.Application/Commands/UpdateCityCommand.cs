using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateCityCommand(int cityId, CityEntity City) : IRequest<ApiResponseModel<CityEntity>>;

    public class UpdateCityCommandHandler(ICityRepository cityRepository) 
        : IRequestHandler<UpdateCityCommand, ApiResponseModel<CityEntity>>
    {
        public async Task<ApiResponseModel<CityEntity>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            return await cityRepository.UpdateCityAsync(request.cityId, request.City);
        }
    }
}
