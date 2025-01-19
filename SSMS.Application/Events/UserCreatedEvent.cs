using MediatR;

namespace SSMS.Application.Events;

public record UserCreatedEvent(Guid userId) : INotification;
