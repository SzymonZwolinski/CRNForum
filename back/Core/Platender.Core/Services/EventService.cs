using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IAuthRepository _authRepository;

        public EventService(IEventRepository eventRepository, IAuthRepository authRepository)
        {
            _eventRepository = eventRepository;
            _authRepository = authRepository;
        }

        public async Task AddUserToEventAsync(string userName, Guid eventId)
        {
            var @event = await _eventRepository.GetEventByIdAsync(eventId);
            var user = await _authRepository.GetUserAsync(userName);

            @event.AddParticipator(user);

            await _eventRepository.UpdateEventAsync(@event);
        }

        public async Task CreateEventAsync(
            string title,
            string description,
            float longtitude,
            float latitude,
            DateTime eventAt,
            float timeZone,
            string creatorUserName)
        {
            var creator = await _authRepository.GetUserAsync(creatorUserName);
            var @event = new Event(
                title, 
                description,
                longtitude, 
                latitude, 
                eventAt,
                timeZone,
                creator);

            await _eventRepository.CreateEventAsync(@event);
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(DateTime? eventAtFrom, DateTime? eventAtTo)
            => await _eventRepository.GetEventsAsync(eventAtFrom, eventAtTo);
        
        public async Task<IEnumerable<Event>> GetUserEventsAsync(
            DateTime? eventAtFrom,
            DateTime? eventAtTo, 
            string userName)
        {
            var user = await _authRepository.GetUserAsync(userName);

            return await _eventRepository.GetEventsForUserAsync(
                eventAtFrom,
                eventAtTo,
                user);
        }
    }
}
