using MediatR;
using SSMS.Core.Entities;
using SSMS.Core.Interfaces;
using SSMS.Core.Models;

namespace SSMS.Application.Queries
{
    public record ValidateUserQuery(LoginModel Login) : IRequest<UserEntity>;

    public class ValidateUserQueryHandler(ILoginRepository loginRepository) 
        : IRequestHandler<ValidateUserQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            return await loginRepository.ValidateUser(request.Login);
        }
    }
}
