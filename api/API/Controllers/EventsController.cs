using api.Application.DTOs;
using api.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.API.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            var eventId = await _eventService.CreateEventAsync(dto);

            return Ok(eventId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id)
        {
            var eventDto = await _eventService.GetEventByIdAsync(id);
            return eventDto != null ? Ok(eventDto) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents([FromQuery] string? status)
        {
            var events = await _eventService.GetAllEventsAsync(status);
            return Ok(events);
        }
    }
}