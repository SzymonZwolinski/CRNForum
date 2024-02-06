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

            @event.AddParticipator(new EventParticipators(@event, user));

            await _eventRepository.UpdateEventAsync(@event);
        }

        public async Task CreateEventAsync(
            string title,
            string description,
            decimal x, 
            decimal y,
            string creatorUserName)
        {
            var creator = await _authRepository.GetUserAsync(creatorUserName);
            var @event = new Event(
                title, 
                description,
                x, 
                y, 
                creator);

            await _eventRepository.CreateEventAsync(@event);
        }

        public async Task<IEnumerable<Event>> GetUserEventsAsync(string userName)
        {
            var user = await _authRepository.GetUserAsync(userName);

            return await _eventRepository.GetEventsForUserAsync(user);
        }
    }
}
