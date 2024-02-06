using Platender.Application.Messages;

namespace Platender.Application.Providers
{
    public interface IEventProvider
    {
        Task CreateEventAsync(AddEvent addEvent, string userName);
    }
}
