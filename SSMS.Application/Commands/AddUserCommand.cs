using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;

namespace SSMS.Application.Commands
{
    public record AddUserCommand(UserEntity User) : IRequest<UserEntity>;

    public class AddUserCommandHandler(IUserRepository userRepository) : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.AddUserAsync(request.User);
        }
    }
}
