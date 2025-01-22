using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record UpdateRoleCommand(int roleId, RoleEntity Role) : IRequest<ApiResponseModel<RoleEntity>>;

    public class UpdateRoleCommandHandler(IRoleRepository roleRepository) 
        : IRequestHandler<UpdateRoleCommand, ApiResponseModel<RoleEntity>>
    {
        public async Task<ApiResponseModel<RoleEntity>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await roleRepository.UpdateRoleAsync(request.roleId, request.Role);
        }
    }
}
