using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateCountryCommand(int countryId, CountryEntity Country) : IRequest<ApiResponseModel<CountryEntity>>;

    public class UpdateCountryCommandHandler(ICountryRepository countryRepository) 
        : IRequestHandler<UpdateCountryCommand, ApiResponseModel<CountryEntity>>
    {
        public async Task<ApiResponseModel<CountryEntity>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryRepository.UpdateCountryAsync(request.countryId, request.Country);
        }
    }
}
