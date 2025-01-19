using MediatR;
using Microsoft.Extensions.Logging;

namespace SSMS.Application.Events
{
    public class SendEmailEventHandler(ILogger<SendEmailEventHandler> logger)
        : INotificationHandler<UserCreatedEvent>
    {
        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("User created: Send email start {UserId}", notification.userId);

            // Send email to the user

            await Task.Delay(2000);

            logger.LogInformation("User created: Send email done {UserId}", notification.userId);
        }
    }
}
