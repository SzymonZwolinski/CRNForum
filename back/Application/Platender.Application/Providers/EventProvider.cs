using Platender.Application.Messages;
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
                userName);
        }
    }
}
