using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;

namespace SSMS.Application.Commands
{
    public record AddUserCommand(UserEntity User) : IRequest<UserEntity>;

    public class AddUserCommandHandler(IUserRepository userRepository, IPublisher publisher) 
        : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.AddUserAsync(request.User);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return user;
        }
    }
}
