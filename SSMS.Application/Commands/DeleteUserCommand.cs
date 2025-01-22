using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteUserCommand(int userId) : IRequest<ApiResponseModel<UserEntity>>;

    public class DeleteUserCommandHandler(IUserRepository userRepository) 
        : IRequestHandler<DeleteUserCommand, ApiResponseModel<UserEntity>>
    {
        public async Task<ApiResponseModel<UserEntity>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeleteUserAsync(request.userId);
        }
    }
}
