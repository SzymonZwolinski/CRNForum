using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platender.Application.Messages;
using Platender.Application.Providers;

namespace Platender.Api.Controllers
{
    [Route("[Controller]")]
    public class EventController : BaseController
    {
        private readonly IEventProvider _eventProvider;

        public EventController(IEventProvider eventProvider)
        {
            _eventProvider = eventProvider;
        }

        [Authorize]
        [HttpPost]
        public async Task<IResult> AddEvent([FromBody] AddEvent addEvent)
        {
            InitalizeHttpContextClaims();
            
            await _eventProvider.CreateEventAsync(addEvent, UserName);

            return Results.Created();
        }
    }
}
