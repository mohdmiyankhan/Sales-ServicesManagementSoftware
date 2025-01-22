using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetRoleByIdQuery(int roleId) : IRequest<ApiResponseModel<RoleEntity>>;

    public class GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        : IRequestHandler<GetRoleByIdQuery, ApiResponseModel<RoleEntity>>
    {
        public async Task<ApiResponseModel<RoleEntity>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await roleRepository.GetRoleByIdAsync(request.roleId);
        }
    }
}
