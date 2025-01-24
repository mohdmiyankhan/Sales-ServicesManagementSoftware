using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteCityCommand(int cityId) : IRequest<ApiResponseModel<CityEntity>>;

    public class DeleteCityCommandHandler(ICityRepository cityRepository) 
        : IRequestHandler<DeleteCityCommand, ApiResponseModel<CityEntity>>
    {
        public async Task<ApiResponseModel<CityEntity>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            return await cityRepository.DeleteCityAsync(request.cityId);
        }
    }
}
