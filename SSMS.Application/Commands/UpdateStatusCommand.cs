using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateStatusCommand(int statusId, StatusEntity Status) : IRequest<ApiResponseModel<StatusEntity>>;

    public class UpdateStatusCommandHandler(IStatusRepository statusRepository) 
        : IRequestHandler<UpdateStatusCommand, ApiResponseModel<StatusEntity>>
    {
        public async Task<ApiResponseModel<StatusEntity>> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            return await statusRepository.UpdateStatusAsync(request.statusId, request.Status);
        }
    }
}
