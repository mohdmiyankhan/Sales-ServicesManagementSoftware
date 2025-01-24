using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteStatusCommand(int statusId) : IRequest<ApiResponseModel<StatusEntity>>;

    public class DeleteStatusCommandHandler(IStatusRepository statusRepository) 
        : IRequestHandler<DeleteStatusCommand, ApiResponseModel<StatusEntity>>
    {
        public async Task<ApiResponseModel<StatusEntity>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            return await statusRepository.DeleteStatusAsync(request.statusId);
        }
    }
}
