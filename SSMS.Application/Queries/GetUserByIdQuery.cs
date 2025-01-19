using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;

namespace SSMS.Application.Queries
{
    public record GetUserByIdQuery(Guid userId) : IRequest<UserEntity>;

    public class GetUserByIdQueryHandler(IUserRepository userRepository)
        : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync(request.userId);
        }
    }
}
