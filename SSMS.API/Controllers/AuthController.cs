using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSMS.Application.Queries;
using SSMS.Core.Models;
using SSMS.Infrastructure.Services;

namespace SSMS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController(ISender sender, IConfiguration configuration) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await sender.Send(new ValidateUserQuery(model));
            if (user is not null)
            {
                var tokenDetails = GenerateToken.JwtToken(user, configuration);
                var login = new Login
                {
                    Message = "User is LoggedIn successfully.",
                    Status = 200,
                    Name = user.Name,
                    Username = user.Username,
                    AccessToken = tokenDetails.token,
                    ExpiryInHours = tokenDetails.expiry
                };
                return StatusCode(login.Status, login);
            }
            else
                return Unauthorized(new
                {
                    Message = "Access is denied due to invalid credentials.",
                    StatusCode = 401
                });
        }
    }
}
