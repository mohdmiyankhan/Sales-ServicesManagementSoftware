using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllStatusesQuery() : IRequest<ApiResponseModel<IEnumerable<StatusEntity>>>;

    public class GetAllStatusesQueryHandler(IStatusRepository statusRepository)
        : IRequestHandler<GetAllStatusesQuery, ApiResponseModel<IEnumerable<StatusEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<StatusEntity>>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return await statusRepository.GetAllStatusesAsync();
        }
    }
}
