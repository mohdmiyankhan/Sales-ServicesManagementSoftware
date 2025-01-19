using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;

namespace SSMS.Application.Queries
{
    public record GetAllUsersQuery() : IRequest<IEnumerable<UserEntity>>;

    public class GetAllUsersQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetAllUsersQuery, IEnumerable<UserEntity>>
    {
        public async Task<IEnumerable<UserEntity>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUsersAsync();
        }
    }
}
