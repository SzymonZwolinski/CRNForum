using Platender.Core.Models;

namespace Platender.Core.Repositories
{
    public interface IEventRepository
    {
        Task CreateEventAsync(Event @event);
        Task UpdateEventAsync(Event @event);
        Task<IEnumerable<Event>> GetEventsForUserAsync(
            DateTime? EventAtFrom,
            DateTime? EventAtTo, 
            User user);
        Task<Event> GetEventByIdAsync(Guid id);
        Task<IEnumerable<Event>> GetEventsAsync(DateTime? EventAtFrom, DateTime? EventAtTo);
    }
}
