using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateUserCommand(int userId, UserEntity User) : IRequest<ApiResponseModel<UserEntity>>;

    public class UpdateUserCommandHandler(IUserRepository userRepository) 
        : IRequestHandler<UpdateUserCommand, ApiResponseModel<UserEntity>>
    {
        public async Task<ApiResponseModel<UserEntity>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserAsync(request.userId, request.User);
        }
    }
}
