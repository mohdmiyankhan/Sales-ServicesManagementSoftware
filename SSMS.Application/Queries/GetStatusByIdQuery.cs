using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetStatusByIdQuery(int statusId) : IRequest<ApiResponseModel<StatusEntity>>;

    public class GetStatusByIdQueryHandler(IStatusRepository statusRepository)
        : IRequestHandler<GetStatusByIdQuery, ApiResponseModel<StatusEntity>>
    {
        public async Task<ApiResponseModel<StatusEntity>> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            return await statusRepository.GetStatusByIdAsync(request.statusId);
        }
    }
}
