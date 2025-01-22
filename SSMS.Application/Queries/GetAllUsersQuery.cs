using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllUsersQuery() : IRequest<ApiResponseModel<IEnumerable<UserEntity>>>;

    public class GetAllUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, ApiResponseModel<IEnumerable<UserEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<UserEntity>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetAllUsersAsync();
        }
    }
}
