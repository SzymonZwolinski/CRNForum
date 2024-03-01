using Platender.Front.Dto;

namespace Platender.Front.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetEventsAsync();
    }
}
