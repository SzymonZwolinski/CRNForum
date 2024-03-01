using Platender.Core.Models;

namespace Platender.Core.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(
            string title,
            string description,
            float longtitude,
            float latitude, 
            DateTime eventAt,
            float timeZone,
            string creatorUserName);
        Task AddUserToEventAsync(string userName, Guid eventId);
        Task<IEnumerable<Event>> GetUserEventsAsync(
            DateTime? eventAtFrom,
            DateTime? eventAtTo,
            string userName);
        Task<IEnumerable<Event>> GetAllEventsAsync(DateTime? eventAtFrom, DateTime? eventAtTo);
    }
}
