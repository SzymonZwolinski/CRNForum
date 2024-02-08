using Microsoft.EntityFrameworkCore;
using Platender.Application.EF;
using Platender.Core.Models;
using Platender.Core.Repositories;

namespace Platender.Application.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly PlatenderDbContext _platenderDbContext;

        public EventRepository(PlatenderDbContext platenderDbContext)
        {
            _platenderDbContext = platenderDbContext;
        }

        public async Task CreateEventAsync(Event @event)
        {
            await _platenderDbContext.AddAsync(@event);
            await _platenderDbContext.SaveChangesAsync();
        } 

        public async Task<Event> GetEventByIdAsync(Guid id)
            => await _platenderDbContext.events
                .Include(x => x.Participators)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Event>> GetEventsAsync(DateTime? EventAtFrom, DateTime? EventAtTo)
        {
            var events = _platenderDbContext.events
                .Include(x => x.Creator)
                .Include(x => x.Participators)
                .Where(x => x.EventAt >= DateTime.UtcNow);
            //TODO: add timezone?

            if(EventAtFrom.HasValue)
            {
                events = events.Where(x => x.EventAt > EventAtFrom.Value);
            }

            if(EventAtTo.HasValue)
            {
                events = events.Where(x => x.EventAt <= EventAtTo.Value);
            }

            return await events.ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsForUserAsync(
            DateTime? EventAtFrom,
            DateTime? EventAtTo,
            User user)
        {
            var events = _platenderDbContext.events
                .Include(x => x.Participators)
                .Where(x =>
                    x.Participators.Any(x => x.User == user)
                    || x.Creator == user);

            if(EventAtFrom.HasValue)
            {
                events.Where(x => x.EventAt >= EventAtFrom);
            }

            if(EventAtTo.HasValue) 
            {
                events.Where(x => x.EventAt <= EventAtTo);
            }

            return await events.ToListAsync();
        }

        public async Task UpdateEventAsync(Event @event)
        {
            _platenderDbContext.Update(@event);

            await _platenderDbContext.SaveChangesAsync();
        }
    }
}
