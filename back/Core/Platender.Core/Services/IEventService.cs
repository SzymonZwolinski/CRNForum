using Platender.Core.Models;

namespace Platender.Core.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(
            string title,
            string description,
            decimal longtitude, 
            decimal latitude, 
            DateTime eventAt,
            decimal timeZone,
            string creatorUserName);
        Task AddUserToEventAsync(string userName, Guid eventId);
        Task<IEnumerable<Event>> GetUserEventsAsync(string userName);
    }
}
