using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddUserCommand(UserEntity User) : IRequest<ApiResponseModel<UserEntity>>;

    public class AddUserCommandHandler(IUserRepository userRepository, IPublisher publisher) 
        : IRequestHandler<AddUserCommand, ApiResponseModel<UserEntity>>
    {
        public async Task<ApiResponseModel<UserEntity>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.AddUserAsync(request.User);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return user;
        }
    }
}
