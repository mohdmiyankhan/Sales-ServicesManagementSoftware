using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record DeleteRoleCommand(int roleId) : IRequest<ApiResponseModel<RoleEntity>>;

    public class DeleteRoleCommandHandler(IRoleRepository roleRepository) 
        : IRequestHandler<DeleteRoleCommand, ApiResponseModel<RoleEntity>>
    {
        public async Task<ApiResponseModel<RoleEntity>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await roleRepository.DeleteRoleAsync(request.roleId);
        }
    }
}
