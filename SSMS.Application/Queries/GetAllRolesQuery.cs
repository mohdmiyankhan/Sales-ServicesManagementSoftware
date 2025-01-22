using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record GetAllRolesQuery() : IRequest<ApiResponseModel<IEnumerable<RoleEntity>>>;

    public class GetAllRolesQueryHandler(IRoleRepository roleRepository)
        : IRequestHandler<GetAllRolesQuery, ApiResponseModel<IEnumerable<RoleEntity>>>
    {
        public async Task<ApiResponseModel<IEnumerable<RoleEntity>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await roleRepository.GetAllRolesAsync();
        }
    }
}
