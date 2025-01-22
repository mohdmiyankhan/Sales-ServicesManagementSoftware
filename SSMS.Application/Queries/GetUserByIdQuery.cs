using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetUserByIdQuery(int userId) : IRequest<ApiResponseModel<UserEntity>>;

    public class GetUserByIdQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByIdQuery, ApiResponseModel<UserEntity>>
    {
        public async Task<ApiResponseModel<UserEntity>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync(request.userId);
        }
    }
}
