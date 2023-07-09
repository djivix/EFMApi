using EFManager.API.Shared.Events;

namespace EFManager.API.Application.Common.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}