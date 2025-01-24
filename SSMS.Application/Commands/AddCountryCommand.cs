using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddCountryCommand(CountryEntity Country) : IRequest<ApiResponseModel<CountryEntity>>;

    public class AddCountryCommandHandler(ICountryRepository countryRepository, IPublisher publisher) 
        : IRequestHandler<AddCountryCommand, ApiResponseModel<CountryEntity>>
    {
        public async Task<ApiResponseModel<CountryEntity>> Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {
            var role = await countryRepository.AddCountryAsync(request.Country);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return role;
        }
    }
}
