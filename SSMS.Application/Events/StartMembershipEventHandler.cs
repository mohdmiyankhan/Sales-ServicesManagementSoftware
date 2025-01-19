using MediatR;
using Microsoft.Extensions.Logging;

namespace SSMS.Application.Events
{
    public class StartMembershipEventHandler(ILogger<SendEmailEventHandler> logger)
        : INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("User created: Membership start {UserId}", notification.userId);

            // Send email to the user

            await Task.Delay(2000);

            logger.LogInformation("User created: Membership done {UserId}", notification.userId);
        }
    }
}
