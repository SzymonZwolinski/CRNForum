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
            _platenderDbContext.Add(@event);

            await _platenderDbContext.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(Guid id)
            => await _platenderDbContext.events
                .Include(x => x.Participators)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Event>> GetEventsForUserAsync(User user)
            => await _platenderDbContext.events
                .Include(x => x.Participators)
                .Where(x =>
                    x.Participators.Any(y => y.User == user) 
                    || x.Creator == user)
                .ToListAsync();

        public async Task UpdateEventAsync(Event @event)
        {
            _platenderDbContext.Update(@event);

            await _platenderDbContext.SaveChangesAsync();
        }
    }
}
