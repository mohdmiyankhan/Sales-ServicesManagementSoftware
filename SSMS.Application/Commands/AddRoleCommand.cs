using MediatR;
using SSMS.Application.Events;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Commands
{
    public record AddRoleCommand(RoleEntity Role) : IRequest<ApiResponseModel<RoleEntity>>;

    public class AddRoleCommandHandler(IRoleRepository roleRepository, IPublisher publisher) 
        : IRequestHandler<AddRoleCommand, ApiResponseModel<RoleEntity>>
    {
        public async Task<ApiResponseModel<RoleEntity>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.AddRoleAsync(request.Role);
            //await publisher.Publish(new UserCreatedEvent(user.Id));
            return role;
        }
    }
}
