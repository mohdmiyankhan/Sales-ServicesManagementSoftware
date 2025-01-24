using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddStatusCommand(StatusEntity Status) : IRequest<ApiResponseModel<StatusEntity>>;

    public class AddStatusCommandHandler(IStatusRepository statusRepository, IPublisher publisher) 
        : IRequestHandler<AddStatusCommand, ApiResponseModel<StatusEntity>>
    {
        public async Task<ApiResponseModel<StatusEntity>> Handle(AddStatusCommand request, CancellationToken cancellationToken)
        {
            var role = await statusRepository.AddStatusAsync(request.Status);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return role;
        }
    }
}
