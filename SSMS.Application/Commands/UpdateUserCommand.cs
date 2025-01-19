using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;

namespace SSMS.Application.Commands
{
    public record UpdateUserCommand(Guid userId, UserEntity User) : IRequest<UserEntity>;

    public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserAsync(request.userId, request.User);
        }
    }
}
