using Platender.Application.DTO;
using Platender.Application.Messages;
using Platender.Application.Messages.Queries;
using Platender.Core.Models;
using Platender.Core.Services;

namespace Platender.Application.Providers
{
    public class EventProvider : IEventProvider
    {
        private readonly IEventService _eventService;

        public EventProvider(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task CreateEventAsync(AddEvent addEvent, string userName)
        {
            await _eventService.CreateEventAsync(
                addEvent.Title, 
                addEvent.Description,
                addEvent.Longtitude, 
                addEvent.Latitude,
                addEvent.EventAt,
                addEvent.TimeZone,
                userName);
        }

        public async Task<IEnumerable<EventDto>> GetAllEvents(GetEvents getEvents)
        {
            var events = await _eventService.GetAllEventsAsync(
                getEvents.EventAtFrom,
                getEvents.EventAtTo);

            return events.Select(x => MapEventToEvenDto(x));
        }

        public async Task<IEnumerable<EventDto>> GetUserEvents(GetEvents getEvents, string userName)
        {
            var events = await _eventService.GetUserEventsAsync(
                getEvents.EventAtFrom, 
                getEvents.EventAtTo,
                userName);

            return events.Select(x => MapEventToEvenDto(x));
        }

        private EventDto MapEventToEvenDto(Event @event)
        {
            return new EventDto(
                @event.Title,
                @event.Description,
                @event.Longtitude,
                @event.Latitude,
                @event.EventAt,
                @event.TimeZone,
                @event.Creator.Username,
                @event.Participators.Count());
        }
    }
}
