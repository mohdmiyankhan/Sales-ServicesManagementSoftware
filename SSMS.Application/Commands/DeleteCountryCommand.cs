using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteCountryCommand(int countryId) : IRequest<ApiResponseModel<CountryEntity>>;

    public class DeleteCountryCommandHandler(ICountryRepository countryRepository) 
        : IRequestHandler<DeleteCountryCommand, ApiResponseModel<CountryEntity>>
    {
        public async Task<ApiResponseModel<CountryEntity>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            return await countryRepository.DeleteCountryAsync(request.countryId);
        }
    }
}
