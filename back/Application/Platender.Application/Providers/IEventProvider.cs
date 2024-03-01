using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;

namespace Platender.Application.Providers
{
    public interface IEventProvider
    {
        Task CreateEventAsync(AddEvent addEvent, string userName);
        Task<IEnumerable<EventDto>> GetUserEvents(GetEvents getEvents, string userName);
        Task<IEnumerable<EventDto>> GetAllEvents(GetEvents getEvents);
    }
}
