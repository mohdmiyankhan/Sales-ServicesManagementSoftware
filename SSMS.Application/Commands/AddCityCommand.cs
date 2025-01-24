using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddCityCommand(CityEntity City) : IRequest<ApiResponseModel<CityEntity>>;

    public class AddCityCommandHandler(ICityRepository cityRepository, IPublisher publisher) 
        : IRequestHandler<AddCityCommand, ApiResponseModel<CityEntity>>
    {
        public async Task<ApiResponseModel<CityEntity>> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
            var role = await cityRepository.AddCityAsync(request.City);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return role;
        }
    }
}
